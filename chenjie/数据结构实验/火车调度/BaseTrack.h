#pragma once
#include <iostream>
#define NULL 0;
using namespace std;
constexpr auto MaxSize = 26;
class BaseTrack
{
public:
	BaseTrack();			 // ���캯��
	~BaseTrack();		     // ��������
	bool push(char &);		 // ��ջ
	bool pop(char &);		 // ��ջ
	void travelAll();		 // ����ջ
	bool isEmpty();			 // ջ�Ƿ�Ϊ��
	bool isFull();			 // ջ�Ƿ�Ϊ��
	int getTop();			 // ���ջ��λ��
	bool isTopEqualto(char); // �Ƚ�ջ��Ԫ���Ƿ��������ͬ
private:
	char data[MaxSize];
	int top;
};

