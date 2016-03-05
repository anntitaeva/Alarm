
#include "pitches.h"

const int SPEAKER = 9; //выход динамика
const int BUTTON = 2; //выход кнопки

int BUTTON_STATE = 0;
int i = 0; // счетчик для мелодии
String getinfo = "0"; //получаемый код через ком-порт
unsigned long minutes = 1000L * 60;
int num = 0; //количество повторов остановки
boolean repeat = false;



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
  if (digitalRead(BUTTON) == LOW && (BUTTON_STATE == 0 || repeat == true))
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
  }
}

void resetData()
{ 
    getinfo = "0";
    BUTTON_STATE=0;
    repeat=false;
    num=0;
    i=0;
}
void loop()
{
  if (getinfo == "0")
  {
    Serial.println("Info from Arduino");
    delay(1000);
    if (Serial.available())
    {
      getinfo = Serial.read();
    }
  }



  if (getinfo == "48")
  {
    setalarm();
    resetData();
   
  }

  if (getinfo == "49")
  {
    setalarm();
    if (BUTTON_STATE == 1 && num == 1)
    {
      if ( repeat == false)
      {
        delay(1 * minutes);
        repeat = true;
        i = 0;
      }

      setalarm();

      if (num == 2)
      { 
        resetData();
      }
    }

  }



}

