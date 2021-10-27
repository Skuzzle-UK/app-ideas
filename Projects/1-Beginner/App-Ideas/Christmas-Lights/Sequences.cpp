#include "Sequences.h"

byte Sequences::_position = 0;
byte Sequences::_selected = 0;
bool Sequences::_playing = true;

void Sequences::Play(RGB_LED rgb_led[]) {
	switch (_selected)
	{
	case 0: // all flashing
		for (int i = 0; i < sizeof rgb_led; i++)
		{
			rgb_led[i].lit = !rgb_led[i].lit;
		}
		delay(2000); //@TODO introduce speed adjustment
		break;
	case 1:
		break;
	case 2:
		break;
	case 3:
		break;
	case 4:
		break;
	case 5:
		break;
	case 6:
		break;
	case 7:
		break;
	default:
		_selected = 0;
		break;
	}
}

void Sequences::PauseResume() {
	_playing = !_playing;
}

void Sequences::NextSequence() {
	if (_selected < MAX_NUMBER_OF_SEQUENCES - 1) {
		_selected++;
	}
	else {
		_selected = 0;
	}
	_position = 0;
}

bool Sequences::Playing() {
	return _playing;
}