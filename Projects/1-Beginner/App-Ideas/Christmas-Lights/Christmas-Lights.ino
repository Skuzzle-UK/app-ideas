/*
 Name:		Christmas_Lights.ino
 Designed for Arduino Mega2560

 Created:	10/20/2021 9:33:12 PM
 Author:	Nick Bailey
*/
#include "LEDSequence.h"

constexpr int LED_LIGHT[]{ 2, 5, 8, 11, 44 }; //Start pin to be used for each sequence light

LEDSequence led_sequence[LEDPattern_MAX];

// the setup function runs once when you press reset or power the board
void setup() {
	for (int i = 0; i < sizeof LED_LIGHT; i++) { //Setup pin modes
		pinMode(LED_LIGHT[i], OUTPUT);
		pinMode(LED_LIGHT[i] + 1, OUTPUT);
		pinMode(LED_LIGHT[i] + 2, OUTPUT);
	}
	
	for (int i = 0; i < LEDPattern_MAX; i++)	{ //Sets up the array of different sequences
		led_sequence[i] = LEDSequence(LEDPattern(i));
	}
}

// the loop function runs over and over again until power down or reset
void loop() {

}
