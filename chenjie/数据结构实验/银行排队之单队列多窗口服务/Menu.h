#pragma once
#include "Customer.h"
#include "Queue.h"
#include "Window.h"
#include <iostream>
#define MaxSize 10
using namespace std;

class Menu
{
public:
	Menu();
	~Menu();
	void cinArriveAndHandleTime(Queue &);					// 输入到达时间与处理时间
	void cinWindowsNumber();								// 输入窗口数
	void StartWork(Queue &, Window(&)[10]);					// 开始工作
	void directToWindow(Customer &, Window(&)[10], int i);	// 无等待，直接去窗口，i为窗口位置
	void afterWaitToWindow(Customer &, Window(&)[10]);		// 经过等待进入窗口
	void timePass(Window(&windows)[10], int passTime);		// 时间流逝
	void calculateTotalAndMaxWaitTime(int waitTime);		// 计算总等待时间与最长等待时间
	void calculateFinalFinishTime(Window(&)[10]);			// 计算最后完成时间
	void coutAverageAndMaxAndFinalTime();					// 输出平均等待时间（输出到小数点后1位）、最长等待时间、最后完成时间
	void coutServiceNumber(Window(&)[10]);					// 编号递增顺序输出每个窗口服务了多少名顾客
	bool isAllWindowsBusy(Window(&)[10]);
	int minRemainTime(Window(&)[10], int &);
private:
	int totalCustomerNumber;
	int totalWindowsNumber;
	int currentTime;
	float totalWaitingTime;
	float averageWaitingTime;
	int maxWaitingTime;
	int finalFinishTime;
};

