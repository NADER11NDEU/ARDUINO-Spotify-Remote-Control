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
ulg ilerisar;
ulg gerisar;
ulg ilerisar2x;
ulg gerisar2x;
ulg pressed_button;
bool artiyuz;
bool artikiyuz;
int lenght_of_buttons_array;
ulg button_codex[];
}mainVariables;
                      //led sh_led  irc_req       shuffle       ileri     geri     ileri2x   geri2x  pressed_button  artiyuz   artikiyuz   array_lenght  button_array
mainVariables my_main = {2,    4,   8,   0xFFFCCC, 0xABCDEF, 0xFEDCBA,0xACCDEF,  0xFCDCBA,    0x0,        false,    false       ,0           ,0}; // 
 
 /*                               vol_up   vol_down  py_ps    next      prev    ch_pos   ch_neg    ch             
unsigned long button_arrays[] = {0xFFA857,0xFFE01F,0xFFC23D,0xFF02FD,0xFF22DD,0xFFE21D,0xFFA25D,0xFF629D,
0xFF6897,0xFF30CF,0xFF18E7,0xFF7A85,0xFF10EF,0xFF38C7,0xFF5AA5,0xFF42BD,0xFF4AB5,0xFF52AD,0xFF906F,0xFF9867,0xFFB04F};
// 0       1          2        3       4        5        6        7         8       9       EQ       100+     200+ */

IRrecv irrecv(11);
decode_results results;

bool justonce = false , stringComplete = false;
sr singer,track_name,get_it = ""; 

void setup(){
  delay(1000);
  get_it.reserve(500); // memory de yer ayır.
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
 TimedAction deneme = TimedAction(400,kayalim);
  
 void kayalim(){
  if (singer.length() > 16 || track_name.length() > 16)
  my_lcd.scrollDisplayLeft();
  }
bool just_once = true;

  void loop(){
  deneme.check(); // çalışmaya ihtiyacı olduğunda çalıştır :) Kind of multi threading.
  if (stringComplete) {
 ////////// CHECK SHUFFLED OR NOT ! //////////////
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
my_main.lenght_of_buttons_array = sizeof(my_button_array) / sizeof(my_button_array[0]); // button arrayın kaç elemanı var ?
just_once = false;

if (!justonce){ //button arrayı structa bir kere yaz
for (int i =0; i<my_main.lenght_of_buttons_array; i++){
  my_main.button_codex[i] = my_button_array[i];
  //Serial.println( my_main.button_codex[i],HEX);
}
justonce = true;
}
//my_lcd.scrollDisplayRight();
//delay(350);
 if(irrecv.decode(&results)){ //herhangi bir butona basıldıysa
 if(my_main.artiyuz == false && my_main.artikiyuz == false) //eğer ileri-geri sar modunda değilsek
 Serial.println(results.value,HEX); // basılan tusu hex olarak porta gönder
 
// delay(300);
 for (int i =0; i<my_main.lenght_of_buttons_array; i++){ //basılan tus benim arrayımda var mı kontrol et. (Burası komple +100 ve +200 konrol yeri. result valueyi içerde yazdırabilirdim ama yazdırmadım)

  if (results.value == my_main.button_codex[i]){ // basılan tus benim arrayımda var mı ? 
     if (my_main.button_codex[i] == 0xFF9867){ // +100 basıldı mı kontrol edelim...
     my_main.artiyuz = true;
     my_main.artikiyuz = false;  
     }
     else if (my_main.button_codex[i] == 0xFFB04F){ // +200 basıldı mı kontrol edelim...
     my_main.artiyuz = false;
     my_main.artikiyuz = true;
     }
     else{ // eğer +100 veya +200 basılmadıysa
     my_main.pressed_button = my_main.button_codex[i]; //basılan tusu kaydet.
     digitalWrite(my_main.led_pin,HIGH);
     delay(150); //500 delay
     digitalWrite(my_main.led_pin,LOW);
     }
     }
     }

 irrecv.resume();
 }
 
  state(my_main.artiyuz,my_main.artikiyuz); // state voidimi çağır
  my_main.pressed_button = 0x0; // pressed_button varialablesini nulla çek

}

void state(bool &control, bool &control_2){ // nerde o eski multithreadlar xd
  ulg saved_ileri; 
  ulg saved_geri;
  if (control){ // +100 basıldıysa
  saved_ileri = my_main.ilerisar;
  saved_geri = my_main.gerisar;
  }
  if (control_2){ //+200 basıldıysa
  saved_ileri = my_main.ilerisar2x;
  saved_geri = my_main.gerisar2x;
  }
  
  if (control || control_2){ //+200 veya +100 basıldıysa daha sonra bastığım tuşu algılayıp istediğim hex değerini porta gönder. Yeni tuşa basana kadar ışıklar yanıp sönsün

     if (my_main.pressed_button == 0xFF906F){ // EQ Basıldı mı ? (shuffle için)
      Serial.println(my_main.shuffle_button,HEX);
      control = false;
      control_2 = false;      
     }
     
     if (my_main.pressed_button == 0xFF02FD){ // next basıldı mı ?
     Serial.println(saved_ileri,HEX);
     control = false;
     control_2 = false;
     }
     else if (my_main.pressed_button == 0xFF22DD){ //prev basıldı mı ?
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


//////////// Serial Event End /////////////////////////////////

     
////////// EEPROM YAZMA - OKUMA İÇİN HAZIR KODLAR. Aynı anda serial porta iki bağlantı yapamadığımdan debug olarak kullandım... SRC: https://mindeon.com/posts/coding-journal/read-write-eeprom/ ////////////
 /*
void writeString(int address, String data)
{
  int stringSize = data.length();
  for(int i=0;i<stringSize;i++)
  {
    EEPROM.write(address+i, data[i]);
  }
  EEPROM.write(address + stringSize,'\0');   //Add termination null character
}
String readString(int address)
{
  char data[255]; //Max 100 Bytes
  int len=0;
  unsigned char k;
  k = EEPROM.read(address);
  while(k != '\0' && len < 255)   //Read until null character
  {
    k = EEPROM.read(address + len);
    data[len] = k;
    len++;
  }
  data[len]='\0';
  return String(data);
}
*/
////////////////////////////////////////////// EEPROM YAZMA - OKUMA KODLARI BİTİŞ //////////////////////////////////////////////
