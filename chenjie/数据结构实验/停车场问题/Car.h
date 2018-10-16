#pragma once
#ifndef _Car
#define _Car
#include "Parking.h"
#include "Pavement.h"
constexpr auto rate = 5;

class Parking;
class Pavement;
class Car
{
public:
	Car();
	~Car();
	void setNumber(int num);										
	int getNumber();
	void setArriveTime(int arr_time);
	int getArriveTime();
	void setLeaveTime(int lea_time);
	int getLeaveTime();
	void setCost();
	int getCost();
	void arrive(Parking & parking, Pavement & pavement);		// ����ͣ��ͣ����������ʱ�����
	void leave(Parking & parking, Parking & tempParking,		// ��������ͣ����
		Pavement & pavement, Car leaveCar);
	void operator =(Car & c);									// ���غ��������ڶ���ֵ
	void operator =(int null);									// ���غ��������ڶ����ʼ��
private:
	int number;													// ���ƺ�
	int arriveTime;												// ����ʱ��
	int leaveTime;												// �뿪ʱ��
	int cost;													// ���ѽ��
	friend class Parking;
	friend class Pavement;
};
#endif
