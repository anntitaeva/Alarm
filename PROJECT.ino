
#include "pitches.h"

const int SPEAKER = 9; //выход динамика
const int BUTTON = 2; //выход кнопки

int BUTTON_STATE = 0;
int i = 0; // счетчик для мелодии
String getinfo = "2"; //получаемый код через ком-порт
int getdone=0;
unsigned long minutes = 1000L * 60;
int num = 0; //количество повторов остановки
boolean done = false; //фиксация остановки


int notes[] = {
  NOTE_A4, NOTE_E3, NOTE_A4, 0,
  NOTE_A4, NOTE_E3, NOTE_A4, 0,
  NOTE_E4, NOTE_D4, NOTE_C4, NOTE_B4, NOTE_A4, NOTE_B4, NOTE_C4, NOTE_D4,
  NOTE_E4, NOTE_E3, NOTE_A4, 0
};

int times[] = {
  250, 250, 250, 250,
  250, 250, 250, 250,
  125, 125, 125, 125, 125, 125, 125, 125,
  250, 250, 250, 250
};

void setup()
{
  pinMode (BUTTON, INPUT);
  Serial.begin(9600);

}



void setalarm()
{
  if (digitalRead(BUTTON) == LOW && BUTTON_STATE == 0)
  {
    tone(SPEAKER, notes[i], times[i]);
    delay(times[i]);

    if (i == 19)
      i = 0;
    else
      i++;
  }

  if (digitalRead(BUTTON) == HIGH)
  {
    BUTTON_STATE = 1;
    num++;
    done = true;
  }
}

void loop()
{
 // delay(1000);
 // Serial.println("Info from Arduino");
 // delay(3000);
  
  if(Serial.available())
     getinfo = Serial.read();
  Serial.println(getinfo);
  
  
  if (getinfo == "48")
    setalarm();

  if (getinfo == "49")
  {
    setalarm();
    if (done == true && num == 1)
    {
      delay(5 * minutes);
      done = false;
      BUTTON_STATE = 0;
      i = 0;
      setalarm();
    }

  }



}

