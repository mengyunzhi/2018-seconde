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
		cout << "### 你的车在临时便道的位置是：" << pavement.findPosition(number) << endl;
		cout << endl;
	}

	else
	{
		parking.push(*this);
		cout << "### 你的车在停车场位置是：" << parking.findPosition(number) << endl;
	}
}

void Car::leave(Parking & parking, Parking & tempParking, Pavement & pavement, Car car)
{
	if (parking.isInParking(number))
	{
		// 找到当前车在停车场的位置
		int pos = parking.findPosition(number) - 1;

		// 该车前面的其他所有车都存到临时停车场
		for (int i = parking.getTop(); i > pos; i--)
		{
			Car tempCar;
			parking.pop(tempCar);
			tempParking.push(tempCar);
		}

		// 该车开出停车场
		parking.pop(car);

		cout << endl;
		cout << "### 车牌号为" << car.number << "的车已开出停车场" << endl;
		cout << endl;

		// 其他车回到原来的停车场
		for (int i = tempParking.getTop(); i >= 0; i--)
		{
			Car tempCar;
			tempParking.pop(tempCar);
			parking.push(tempCar);

			cout << endl;
			cout << "### 车牌号为" << tempCar.number << "的车在停车场的位置变更为:";
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
