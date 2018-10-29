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
	bool isHeadEqualto(char);		// �Ƚ϶�ͷԪ���Ƿ��������ͬ
	bool toTrack2(Track2 &);		// ����ͷԪ���Ƶ�����2
	bool toTrack3(Track3 &);		// ����ͷԪ���Ƶ�����3
	char getHeadValue();
	int getSize();
private:
	Node *head;
	Node *tail;
	int size;
	friend class Menu;
};

