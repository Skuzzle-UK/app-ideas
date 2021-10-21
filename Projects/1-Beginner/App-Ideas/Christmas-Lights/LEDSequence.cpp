#include "LEDSequence.h"

LEDSequence::LEDSequence(){}
LEDSequence::LEDSequence(LEDPattern ptn) {
	pattern = ptn;
}
LEDSequence::LEDSequence(LEDPattern ptn, RGB rgb[]) {
	pattern = ptn;
}
LEDSequence::LEDSequence(LEDPattern ptn, RGB rgb[], int spd) {
	pattern = ptn;
}
LEDSequence::LEDSequence(const LEDSequence& sequence) {
	playing = sequence.playing;
	speed = sequence.speed;
	pattern = sequence.pattern;
}
LEDSequence::~LEDSequence(){}

void LEDSequence::Play()
{
	// TODO: Add your implementation code here.
}


void LEDSequence::Stop()
{
	// TODO: Add your implementation code here.
}
