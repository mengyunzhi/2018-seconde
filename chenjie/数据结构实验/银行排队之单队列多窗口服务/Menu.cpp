#include "Menu.h"
#include<iomanip>


Menu::Menu()
{
	totalCustomerNumber = 0;
	totalWindowsNumber = 0;
	currentTime = 0;
	totalWaitingTime = 0;
	averageWaitingTime = 0;
	maxWaitingTime = 0;
	finalFinishTime = 0;
}


Menu::~Menu()
{
}


void Menu::cinArriveAndHandleTime(Queue & queue)
{
	// 输入顾客总数
	int num = 0;
	cin >> num;
	if (num > 1000) {
		num = 1000;
	}
	totalCustomerNumber = num;

	// 输入到达时间与处理时间，并将顾客存到队列当中
	for (int i = 0; i < totalCustomerNumber; i++) {
		int arriveTime;
		int handleTime;
		cin >> arriveTime >> handleTime;
		Customer *customer = new Customer(arriveTime, handleTime);
		queue.push(*customer);
		delete customer;
	}
}

void Menu::cinWindowsNumber()
{
	int num = -1;
	cin >> num;
	if (num > 10) {
		num = 10;
	}
	totalWindowsNumber = num;
}

void Menu::StartWork(Queue & queue, Window(&windows)[10])
{
	// 当队列不为空
	while (!queue.isEmpty()) {
		// 队列抛出一个顾客
		Customer * temp = new Customer();
		queue.pop(*temp);

		if (temp->getArriveTime() > currentTime)
		{
			// 流失时间 = 队头顾客到达时间 - 当前时间
			int passTime = temp->getArriveTime() - currentTime;

			// 时间流逝
			timePass(windows, passTime);
		}

		// 查看是否有空闲窗口
		int i = 0;
		while (i < totalWindowsNumber) {
			// 如果此窗口正忙，则查看下一个窗口
			if (windows[i].isBusy()) {
				i++;
			}
			else {
				// 如果此窗口空闲，则顾客直接进入窗口，跳出循环
				directToWindow(*temp, windows, i);
				delete temp;
				break;
			}
		}
		// 如果i==窗口总数，表示窗口没有一个空闲，顾客需要等待一段时间
		if (i == totalWindowsNumber) {
			afterWaitToWindow(*temp, windows);
			delete temp;
		}
	}

	// 队列为空，计算并设置最后完成时间
	calculateFinalFinishTime(windows);
}
void Menu::directToWindow(Customer & temp, Window(&windows)[10], int i)
{
	// 顾客等待时间置为0
	temp.setWaitTime(0);

	// 顾客进入窗口
	windows[i].customerGoInTo(temp);
}
void Menu::afterWaitToWindow(Customer & temp, Window(&windows)[10])
{
	int position = -1;	// 剩余时间最少的窗口的位置
	int passTime = minRemainTime(windows, position); // 有空窗需要等待的最少的时间

	// 顾客经过了等待时间
	timePass(windows, passTime);

	// 顾客的等待时间为当前时间 - 到达时间
	int waitTime = currentTime - temp.getArriveTime();
	temp.setWaitTime(waitTime);

	// 计算总等待时间与最大等待时间
	calculateTotalAndMaxWaitTime(waitTime);

	// 更改窗口状态
	windows[position].customerGoInTo(temp);
}
// 时间流逝
void Menu::timePass(Window(&windows)[10], int passTime)
{
	// 当前时间流逝
	currentTime += passTime;
	for (int i = 0; i < totalWindowsNumber; i++) {
		if (windows[i].isBusy()) {
			// 计算窗口剩余时间
			int remainTime = windows[i].getRemainTime() - passTime;
			// 当窗口的剩余时间<=0,则说明事务处理完毕
			if (remainTime <= 0) {
				// 剩余时间为0
				windows[i].setRemainTime(0);
				// 更改当前窗口状态
				windows[i].changeStatus();
				// 顾客从窗口离开
				windows[i].pop();
			}
			else {
				windows[i].setRemainTime(remainTime);
			}
		}
	}
}

void Menu::calculateTotalAndMaxWaitTime(int waitTime)
{
	// 累计等待时间
	totalWaitingTime += waitTime;
	// 当等待时间大于最大等待时间，设置其为最长等待时间
	if (waitTime > maxWaitingTime) {
		maxWaitingTime = waitTime;
	}
}

void Menu::calculateFinalFinishTime(Window(&windows)[10])
{
	int maxTime = 0;
	for (int i = 0; i < totalWindowsNumber; i++) {
		int remainTime = windows[i].getRemainTime();
		if (remainTime > maxTime) {
			maxTime = remainTime;
		}
	}
	finalFinishTime = currentTime + maxTime;
}

void Menu::coutAverageAndMaxAndFinalTime()
{
	averageWaitingTime = totalWaitingTime / totalCustomerNumber;
	cout << setiosflags(ios::fixed) << setprecision(1) << averageWaitingTime;
	cout << ' ';
	cout << maxWaitingTime << ' ' << finalFinishTime << endl;
}

void Menu::coutServiceNumber(Window(&windows)[10])
{
	int i = 0;
	for (; i < totalWindowsNumber - 1; i++) {
		cout << windows[i].getserviceNumber() << ' ';
	}
	cout << windows[i].getserviceNumber();
}

bool Menu::isAllWindowsBusy(Window(&windows)[10])
{
	for (int i = 0; i < totalWindowsNumber; i++) {
		if (!windows[i].isBusy()) {
			return false;
		}
	}
	return true;
}

int Menu::minRemainTime(Window(&windows)[10], int & position)
{
	int min = 999;
	for (int i = 0; i < totalWindowsNumber; i++) {
		int remainTime = windows[i].getRemainTime();
		if (remainTime < min) {
			min = remainTime;
			position = i;
		}
	}
	return min;
}