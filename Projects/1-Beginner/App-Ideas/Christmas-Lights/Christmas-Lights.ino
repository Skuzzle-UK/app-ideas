/*
 Name:		Christmas_Lights.ino
 Designed for Arduino Mega2560

 Created:	10/20/2021 9:33:12 PM
 Author:	Nick Bailey
*/
#include "LEDSequence.h"
#include "RGB_LED.h"

constexpr int LED_LIGHT[]{ 2, 5, 8, 11, 44 }; // Start pin to be used for each RGB_LED

RGB_LED rgb_led[5];
LEDSequence led_sequence[LEDPattern_MAX];


// the setup function runs once when you press reset or power the board
void setup() {
	for (int i = 0; i < sizeof LED_LIGHT; i++) { // Set up array of LEDs
		rgb_led[i] = (RGB_LED(LED_LIGHT[i], LED_LIGHT[i] + 1, LED_LIGHT[i] + 2));
	}
	
	for (int i = 0; i < LEDPattern_MAX; i++)	{ // Sets up the array of different sequences
		led_sequence[i] = LEDSequence(LEDPattern(i));
	}
}

// the loop function runs over and over again until power down or reset
void loop() {

}
