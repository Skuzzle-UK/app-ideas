/*
 Name:		Christmas_Lights.ino
 Designed for Arduino Mega2560

 Created:	10/20/2021 9:33:12 PM
 Author:	Nick Bailey
*/
#include "RGB_LED.h"
#include "Sequences.h"

constexpr byte NEXT_BUTTON_PIN = 20;
constexpr byte PAUSE_BUTTON_PIN = 21;
constexpr byte COLOUR_PIN = 22;
constexpr byte LED_LIGHT[]{ 2, 5, 8, 11, 44 }; // Start pin to be used for each RGB_LED
RGB_LED rgb_led[5];

// the setup function runs once when you press reset or power the board
void setup() {
	attachInterrupt(digitalPinToInterrupt(NEXT_BUTTON_PIN), Sequences::NextSequence, LOW);
	attachInterrupt(digitalPinToInterrupt(PAUSE_BUTTON_PIN), Sequences::PauseResume, LOW);
	attachInterrupt(digitalPinToInterrupt(PAUSE_BUTTON_PIN), NewColour, LOW);

	for (int i = 0; i < sizeof LED_LIGHT; i++) { // Set up array of LEDs
		rgb_led[i] = (RGB_LED(LED_LIGHT[i], LED_LIGHT[i] + 1, LED_LIGHT[i] + 2));
	}
}

// the loop function runs over and over again until power down or reset
void loop() {
	if (Sequences::Playing) {
		Sequences::Play(rgb_led);
	}
}

void NewColour() {
	for (int i = 0; i < sizeof LED_LIGHT; i++) { // Set up array of LEDs
		//change colour code for rgb_led[i]
	}
}