#include "Menu.h"



Menu::Menu()
{

}


Menu::~Menu()
{
}

void Menu::cinFirstRow(Track1 &track1)
{
	char item;
	while (cin.get() != '\n')
	{
		cin.unget();
		cin >> item;
		track1.push(item);
	}
}

void Menu::cinSecondRow(Track1 &temp)
{
	char item;
	while (cin.get() != '\n')
	{
		cin.unget();
		cin >> item;
		temp.push(item);
	}
}

void Menu::coutOperationSequence(Track1 & track1, Track1 & temp)
{
	Track2 track2;
	Track3 track3;
	Track1 operationSequence;
	int size = track1.getSize();
	int opquTail;
	bool status = true;
	for (int i = 0; i < size; i++)
	{
		if (track1.isHeadEqualto(temp.getHeadValue()))
		{
			track1.toTrack2(track2);
			char t;
			char test = '+';
			temp.pop(t);
			operationSequence.push(test);
		}
		else {
			char test2 = '-';
			track1.toTrack3(track3);
			operationSequence.push(test2);
		}
	}
	int size1 = track3.getTop();
	for (int i = 0; i < size1+1; i++)
	{
		if (track3.isTopEqualto(temp.getHeadValue()))
		{
			track3.toTrack2(track2);
			char t;
			char test3 = '*';
			temp.pop(t);
			operationSequence.push(test3);
		}
		else {
			status = false;
			cout << "Are you kidding me?";
			break;
		}		
	}
	if (status)
	{
		operationSequence.disPlay();
	}
}
