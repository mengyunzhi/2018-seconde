#pragma once
#include "Track3.h"
class Node
{
private:
	friend class Track1;
	char data;
	Node *next;
};
class Track1
{
public:
	Track1();
	~Track1();
	bool pop(char &);
	bool push(char &);
	void disPlay();
	bool isEmpty();
	bool isHeadEqualto(char);		// 比较队头元素是否与参数相同
	bool toTrack2(Track2 &);		// 将队头元素移到车厢2
	bool toTrack3(Track3 &);		// 将队头元素移到车厢3
	char getHeadValue();
	int getSize();
private:
	Node *head;
	Node *tail;
	int size;
	friend class Menu;
};

