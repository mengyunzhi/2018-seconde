#include "Car.h"
#include "Parking.h"
#include "Pavement.h"
#include <iostream>
using namespace std;

Car::Car()
{
	number = 0;
	arriveTime = 0;
	leaveTime = 0;
	cost = 0;
}


Car::~Car()
{
}

void Car::setNumber(int num)
{
	number = num;
}

int Car::getNumber()
{
	return number;
}

void Car::setArriveTime(int arr_time)
{
	arriveTime = arr_time;
}

int Car::getArriveTime()
{
	return arriveTime;
}

void Car::setLeaveTime(int lea_time)
{
	leaveTime = lea_time;
}

int Car::getLeaveTime()
{
	return leaveTime;
}

void Car::setCost()
{
	cost = rate * (leaveTime - arriveTime);
}

int Car::getCost()
{
	return cost;
}

void Car::arrive(Parking & parking, Pavement & pavement)
{
	if (parking.isFull())
	{
		pavement.push(*this);
		cout << endl;
		cout << "### ��ĳ�����ʱ�����λ���ǣ�" << pavement.findPosition(number) << endl;
		cout << endl;
	}

	else
	{
		parking.push(*this);
		cout << "### ��ĳ���ͣ����λ���ǣ�" << parking.findPosition(number) << endl;
	}
}

void Car::leave(Parking & parking, Parking & tempParking, Pavement & pavement, Car car)
{
	if (parking.isInParking(number))
	{
		// �ҵ���ǰ����ͣ������λ��
		int pos = parking.findPosition(number) - 1;

		// �ó�ǰ����������г����浽��ʱͣ����
		for (int i = parking.getTop(); i > pos; i--)
		{
			Car tempCar;
			parking.pop(tempCar);
			tempParking.push(tempCar);
		}

		// �ó�����ͣ����
		parking.pop(car);

		cout << endl;
		cout << "### ���ƺ�Ϊ" << car.number << "�ĳ��ѿ���ͣ����" << endl;
		cout << endl;

		// �������ص�ԭ����ͣ����
		for (int i = tempParking.getTop(); i >= 0; i--)
		{
			Car tempCar;
			tempParking.pop(tempCar);
			parking.push(tempCar);

			cout << endl;
			cout << "### ���ƺ�Ϊ" << tempCar.number << "�ĳ���ͣ������λ�ñ��Ϊ:";
			cout << parking.findPosition(tempCar.number) << endl;
			cout << endl;
		}
	}
}

void Car::operator =(Car & c)
{
	this->number = c.getNumber();
	this->arriveTime = c.getArriveTime();
	this->cost = c.getCost();
	this->leaveTime = c.getLeaveTime();
}

void Car::operator=(int null)
{
	this->number = null;
	this->arriveTime = null;
	this->leaveTime = null;
	this->cost = null;
}
