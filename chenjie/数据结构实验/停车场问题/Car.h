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
	void arrive(Parking & parking, Pavement & pavement);		// 将车停到停车场或者临时便道上
	void leave(Parking & parking, Parking & tempParking,		// 将车开出停车场
		Pavement & pavement, Car leaveCar);
	void operator =(Car & c);									// 重载函数，用于对象赋值
	void operator =(int null);									// 重载函数，用于对象初始化
private:
	int number;													// 车牌号
	int arriveTime;												// 到达时间
	int leaveTime;												// 离开时间
	int cost;													// 花费金额
	friend class Parking;
	friend class Pavement;
};
#endif
