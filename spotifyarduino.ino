#include <IRremote.h>
#include <EEPROM.h>
#include <LiquidCrystal_I2C.h>
#include <TimedAction.h>
#undef debug_mode

#define BACKLIGHT_PIN     3
LiquidCrystal_I2C my_lcd(0x3F,2,1,0,4,5,6,7);
 
typedef unsigned long ulg;
typedef String sr;

typedef struct{
int led_pin;
int shuffle_led_pin;
int irc_red_led_pin;
ulg shuffle_button;
ulg forward_song;
ulg rewind_song;
ulg forward_song2x;
ulg rewind_song2x;
ulg pressed_button;
bool artiyuz;
bool artikiyuz;
int lenght_of_buttons_array;
ulg button_codex[];
}mainVariables;
                    
mainVariables my_main = {2,4,8,0xFFFCCC,0xABCDEF,0xFEDCBA,0xACCDEF,  0xFCDCBA,0x0,false,false,0,0};
 
IRrecv irrecv(11);
decode_results results;

bool justonce = false , stringComplete = false;
sr singer,track_name,get_it = ""; 

void setup(){
  delay(1000);
  get_it.reserve(500); 
  singer.reserve(1000);
  track_name.reserve(1000);
  pinMode(my_main.shuffle_led_pin,OUTPUT);
  pinMode(my_main.irc_red_led_pin,OUTPUT);
  pinMode(my_main.led_pin,OUTPUT); 
  Serial.begin(9600);
  irrecv.enableIRIn();
  my_lcd.begin(16,2);
  my_lcd.setBacklightPin(BACKLIGHT_PIN,POSITIVE);
  my_lcd.setBacklight(HIGH);
  
}

ulg my_button_array[] = {0xFFE01F,0xFFA857,0xFFC23D,0xFF02FD,0xFF22DD,0xFFE21D,0xFFA25D,0xFF629D,0xFF6897,0xFF30CF,0xFF18E7,0xFF7A85,0xFF10EF,0xFF38C7,0xFF5AA5,0xFF42BD,0xFF4AB5,0xFF52AD,0xFF906F,0xFF9867,0xFFB04F,0xFFA857};
 int scrollCursor = 16;
 int stringStart, stringStop = 0;
 TimedAction scrollStarter = TimedAction(400,scrollThread);
  
 void scrollThread(){
  if (singer.length() > 16 || track_name.length() > 16)
  my_lcd.scrollDisplayLeft();
  }
bool just_once = true;

  void loop(){
  scrollStarter.check(); // protothreading. Trigger scrollThread every 400ms.
  if (stringComplete) {
 ////////// CHECK SHUFFLED OR NOT  //////////////
  if (get_it.equals("shuffled$")){
  digitalWrite(4,HIGH);
  goto end;
  }
  else if (get_it.equals("notsf$")){
  digitalWrite(4,LOW);
  goto end;
  }
  //////////////// END OF CHECK //////////////////

  /////////////// GET SINGER AND TRACK_NAME INFORMATIONS ////////////////////////
  singer = get_it.substring(0, get_it.indexOf("\n"));
  track_name = get_it.substring(get_it.indexOf("\n")+1,get_it.indexOf("$"));
  my_lcd.clear();
  my_lcd.home();
  my_lcd.print(track_name);
  my_lcd.setCursor(0,1);
  my_lcd.print(singer);
 
  end:
  get_it = "";
  stringComplete = false;
  digitalWrite(my_main.irc_red_led_pin,LOW);   

  /////////////// END OF GETTING INFORMATIONS ///////////////////////////////////////////
  }
if (just_once == true)
my_main.lenght_of_buttons_array = sizeof(my_button_array) / sizeof(my_button_array[0]); 
just_once = false;

if (!justonce){ //Write button arrays into structs once.
for (int i =0; i<my_main.lenght_of_buttons_array; i++){
  my_main.button_codex[i] = my_button_array[i];
}
justonce = true;
}

 if(irrecv.decode(&results)){ //If pressed any keys
 if(my_main.artiyuz == false && my_main.artikiyuz == false) // If we are not in  back and forth wraps mode 
 Serial.println(results.value,HEX); // Send pressed key to port as hex 
 
// delay(300);
 for (int i =0; i<my_main.lenght_of_buttons_array; i++){

  if (results.value == my_main.button_codex[i]){ // Check if pressed key in my button array or not.
     if (my_main.button_codex[i] == 0xFF9867){ // Is pressed +100 button ?
     my_main.artiyuz = true;
     my_main.artikiyuz = false;  
     }
     else if (my_main.button_codex[i] == 0xFFB04F){ // Is pressed +200 button ?
     my_main.artiyuz = false;
     my_main.artikiyuz = true;
     }
     else{ 
     my_main.pressed_button = my_main.button_codex[i]; //Save pressed button                     
     digitalWrite(my_main.led_pin,HIGH);
     delay(150); //500 delay
     digitalWrite(my_main.led_pin,LOW);
     }
     }
     }

 irrecv.resume();
 }
 
  state(my_main.artiyuz,my_main.artikiyuz); // call state
  my_main.pressed_button = 0x0; 

}

void state(bool &control, bool &control_2){ 
  ulg saved_ileri; 
  ulg saved_geri;
  if (control){ // if pressed +100 button
  saved_ileri = my_main.forward_song;
  saved_geri = my_main.rewind_song;
  }
  if (control_2){ //if pressed +200 button
  saved_ileri = my_main.forward_song2x;
  saved_geri = my_main.rewind_song2x;
  }
  
  if (control || control_2){ //If pressed +200 or +100 button, 

     if (my_main.pressed_button == 0xFF906F){ // is EQ button pressed ?(for shuffle)
      Serial.println(my_main.shuffle_button,HEX);
      control = false;
      control_2 = false;      
     }
     
     if (my_main.pressed_button == 0xFF02FD){ // is pressed next ?
     Serial.println(saved_ileri,HEX);
     control = false;
     control_2 = false;
     }
     else if (my_main.pressed_button == 0xFF22DD){ //is pressed prev ?
     Serial.println(saved_geri,HEX);
     control = false;
     control_2 = false;
     }
     delay(50);
     digitalWrite(my_main.led_pin,HIGH);
     delay(50);
     digitalWrite(my_main.led_pin,LOW);
     }
     }



//////////// Arduino tutorial src: https://www.arduino.cc/en/Tutorial/SerialEvent ///////////
   
void serialEvent() {
  while (Serial.available()) {
     digitalWrite(my_main.irc_red_led_pin,HIGH);
     char inChar = (char)Serial.read();
     get_it += inChar;
     delay(50);
     if (inChar == '$'){
      stringComplete = true;
    }
    
                            }
                   }


