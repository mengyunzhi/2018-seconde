#pragma once
#include <iostream>
#define NULL 0;
using namespace std;
constexpr auto MaxSize = 26;
class BaseTrack
{
public:
	BaseTrack();			 // 构造函数
	~BaseTrack();		     // 析构函数
	bool push(char &);		 // 入栈
	bool pop(char &);		 // 出栈
	void travelAll();		 // 遍历栈
	bool isEmpty();			 // 栈是否为空
	bool isFull();			 // 栈是否为满
	int getTop();			 // 获得栈顶位置
	bool isTopEqualto(char); // 比较栈顶元素是否与参数相同
private:
	char data[MaxSize];
	int top;
};

