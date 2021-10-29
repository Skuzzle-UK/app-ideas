#pragma once
#include "RGB_LED.h"

constexpr byte MAX_NUMBER_OF_SEQUENCES = 8;

class Sequences
{
public:
	static void Play(RGB_LED[]);
	static void PauseResume();
	static void NextSequence();
	static bool Playing();

private:
	static byte _position;
	static byte _selected;
	static bool _playing;
	static int _speed;
	static void _AdvancePosition(int);
};

