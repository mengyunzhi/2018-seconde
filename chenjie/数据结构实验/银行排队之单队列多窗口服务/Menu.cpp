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
	// ����˿�����
	int num = 0;
	cin >> num;
	if (num > 1000) {
		num = 1000;
	}
	totalCustomerNumber = num;

	// ���뵽��ʱ���봦��ʱ�䣬�����˿ʹ浽���е���
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
	// �����в�Ϊ��
	while (!queue.isEmpty()) {
		// �����׳�һ���˿�
		Customer * temp = new Customer();
		queue.pop(*temp);

		if (temp->getArriveTime() > currentTime)
		{
			// ��ʧʱ�� = ��ͷ�˿͵���ʱ�� - ��ǰʱ��
			int passTime = temp->getArriveTime() - currentTime;

			// ʱ������
			timePass(windows, passTime);
		}

		// �鿴�Ƿ��п��д���
		int i = 0;
		while (i < totalWindowsNumber) {
			// ����˴�����æ����鿴��һ������
			if (windows[i].isBusy()) {
				i++;
			}
			else {
				// ����˴��ڿ��У���˿�ֱ�ӽ��봰�ڣ�����ѭ��
				directToWindow(*temp, windows, i);
				delete temp;
				break;
			}
		}
		// ���i==������������ʾ����û��һ�����У��˿���Ҫ�ȴ�һ��ʱ��
		if (i == totalWindowsNumber) {
			afterWaitToWindow(*temp, windows);
			delete temp;
		}
	}

	// ����Ϊ�գ����㲢����������ʱ��
	calculateFinalFinishTime(windows);
}
void Menu::directToWindow(Customer & temp, Window(&windows)[10], int i)
{
	// �˿͵ȴ�ʱ����Ϊ0
	temp.setWaitTime(0);

	// �˿ͽ��봰��
	windows[i].customerGoInTo(temp);
}
void Menu::afterWaitToWindow(Customer & temp, Window(&windows)[10])
{
	int position = -1;	// ʣ��ʱ�����ٵĴ��ڵ�λ��
	int passTime = minRemainTime(windows, position); // �пմ���Ҫ�ȴ������ٵ�ʱ��

	// �˿;����˵ȴ�ʱ��
	timePass(windows, passTime);

	// �˿͵ĵȴ�ʱ��Ϊ��ǰʱ�� - ����ʱ��
	int waitTime = currentTime - temp.getArriveTime();
	temp.setWaitTime(waitTime);

	// �����ܵȴ�ʱ�������ȴ�ʱ��
	calculateTotalAndMaxWaitTime(waitTime);

	// ���Ĵ���״̬
	windows[position].customerGoInTo(temp);
}
// ʱ������
void Menu::timePass(Window(&windows)[10], int passTime)
{
	// ��ǰʱ������
	currentTime += passTime;
	for (int i = 0; i < totalWindowsNumber; i++) {
		if (windows[i].isBusy()) {
			// ���㴰��ʣ��ʱ��
			int remainTime = windows[i].getRemainTime() - passTime;
			// �����ڵ�ʣ��ʱ��<=0,��˵�����������
			if (remainTime <= 0) {
				// ʣ��ʱ��Ϊ0
				windows[i].setRemainTime(0);
				// ���ĵ�ǰ����״̬
				windows[i].changeStatus();
				// �˿ʹӴ����뿪
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
	// �ۼƵȴ�ʱ��
	totalWaitingTime += waitTime;
	// ���ȴ�ʱ��������ȴ�ʱ�䣬������Ϊ��ȴ�ʱ��
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