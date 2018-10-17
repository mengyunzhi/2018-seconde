#include <iostream>
#include "Parking.h"
#include "Car.h"
#include "Pavement.h"
using namespace std;
bool isNumberFalse(int number);
bool isTimeFalse(int &leaveTime, int &arriveTime);



int main()
{
	Parking parking;
	Parking tempParking;
	Pavement pavement;

	int arriveTime = 0;
	bool status = true;
	cout << "<!-- 停车场管理系统 -->" << endl;
	cout << "@author 陈杰 174311" << endl;
	while (status)
	{
		char option = '!';

		cout << "A : 到达" << endl;
		cout << "B : 查看停车场情况" << endl;
		cout << "C : 查看临时便道情况" << endl;
		cout << "D : 离开" << endl;
		cout << "! : 退出" << endl;
		cout << "(!-_-) 请选择：";
		//cin >> option;
		//cout << "(!-_-) 请选择1：";
		cin >> option;

		switch (option)
		{
		case 'A':
		{
			int number;
			cout << "(!-_-) 请输入车牌号:";
			cin >> number;


			// 判断输入的内容是否合法
			if (isNumberFalse(number)) continue;

			// 判断此车牌号是否已经存在
			if (parking.isInParking(number) || pavement.isInPavement(number))
			{
				cout << endl;
				cout << "!!! ERROR:此车牌号已存在,请重新操作 !!!" << endl;
				cout << endl;
				continue;
			}

			int time;
			Car car;
			car.setNumber(number);

			cout << "(!-_-) 请输入到达时间：";
			cin >> time;

			// 判断输入的内容是否合法
			if (isNumberFalse(number)) continue;

			// 判断输入的时间是否有误
			if (isTimeFalse(time, arriveTime)) continue;

			arriveTime = time;

			car.setArriveTime(arriveTime);

			car.arrive(parking, pavement);

			break;
		}

		case 'B':
		{
			parking.display();
			break;
		}
		case 'C':
		{
			pavement.display();
			break;
		}

		case 'D':
		{
			int number;
			cout << "(!-_-) 请输入车牌号:";
			cin >> number;

			// 判断输入的内容是否合法
			if (isNumberFalse(number)) continue;

			if (parking.isInParking(number))
			{
				Car car = parking.findByNumber(number);

				int leaveTime;
				cout << "(!-_-) 请输入离开时间：";
				cin >> leaveTime;

				// 判断输入的内容是否合法
				if (isNumberFalse(number)) continue;

				// 判断输入的时间是否有误
				if (isTimeFalse(leaveTime, arriveTime)) continue;

				car.leave(parking, tempParking, pavement, car);
				car.setLeaveTime(leaveTime);
				car.setCost();

				cout << endl;
				cout << "*** 应付金额为：" << car.getCost() <<"元 ***"<<endl;
				cout << endl;
				// 如果临时便道有车，则将便道第一辆车开到停车场里
				if (!pavement.isEmpty())
				{
					Car tempCar;
					pavement.pop(tempCar);

					// 上一辆车的离开时间是下一辆车的进入时间
					tempCar.setArriveTime(leaveTime);

					parking.push(tempCar);

					cout << "### 临时便道上车牌号为" << tempCar.getNumber() << "的车停入停车场 ###" << endl;
					cout << "### 停入时间为：" << tempCar.getArriveTime()<<" ###"<<endl;
					cout << endl;
				}
			}
			else if (pavement.isInPavement(number))
			{
				cout << "!!! ERROR:你的车还在临时便道上，不能离开 !!!" << endl;
			}
			else
			{
				cout << "!!! ERROR:停车场内没有这辆车 !!!" << endl;
			}

			break;
		}

		case '!': { status = false; }
		default:
		{
			cout << endl;
			cout << "!!! ERROR:无此选项,请重新操作 !!!" << endl;
			cout << endl;
			break;
		}

		}

		cout << endl;
		cout << " <!--------------  -------------->" << endl;
		cout << endl;
	}
	return 0;
}








bool isNumberFalse(int number)
{
	return number == 0;
}

bool isTimeFalse(int &leaveTime, int &arriveTime)
{
	if (leaveTime <= arriveTime)
	{
		cout << endl;
		cout << "!!! ERROR:输入的时间应该大于上一辆车的到达时间 !!!" << endl;
		cout << endl;
		return true;
	}
	else
	{
		return false;
	}
}


/*

int main()
{
	int i;
	cin >> i;
	return 0;
}

*/


