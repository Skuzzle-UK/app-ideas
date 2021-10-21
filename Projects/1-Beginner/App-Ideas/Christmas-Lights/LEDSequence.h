#pragma once
enum class LEDPattern {
	White,
	Red,
	Blue,
	Green,
	Pink,
	Yellow,
	AllFlashing,
	AlternatingFade,
	Chase,
	ColourFade,
};
const int LEDPattern_MAX = 10;

struct RGB {
	int red = 0;
	int green = 0;
	int blue = 0;
};

class LEDSequence {
public:
	bool playing = false;
	int speed = 2;
	LEDPattern pattern = LEDPattern::White;
	
	LEDSequence();
	LEDSequence(LEDPattern);
	LEDSequence(LEDPattern, RGB[]);
	LEDSequence(LEDPattern, RGB[], int);
	LEDSequence(const LEDSequence&);
	~LEDSequence();

	void Play();
	void Stop();
};