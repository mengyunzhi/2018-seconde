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
	cout << "<!-- ͣ��������ϵͳ -->" << endl;
	cout << "@author �½� 174311" << endl;
	while (status)
	{
		char option = '!';

		cout << "A : ����" << endl;
		cout << "B : �鿴ͣ�������" << endl;
		cout << "C : �鿴��ʱ������" << endl;
		cout << "D : �뿪" << endl;
		cout << "! : �˳�" << endl;
		cout << "(!-_-) ��ѡ��";
		//cin >> option;
		//cout << "(!-_-) ��ѡ��1��";
		cin >> option;

		switch (option)
		{
		case 'A':
		{
			int number;
			cout << "(!-_-) �����복�ƺ�:";
			cin >> number;


			// �ж�����������Ƿ�Ϸ�
			if (isNumberFalse(number)) continue;

			// �жϴ˳��ƺ��Ƿ��Ѿ�����
			if (parking.isInParking(number) || pavement.isInPavement(number))
			{
				cout << endl;
				cout << "!!! ERROR:�˳��ƺ��Ѵ���,�����²��� !!!" << endl;
				cout << endl;
				continue;
			}

			int time;
			Car car;
			car.setNumber(number);

			cout << "(!-_-) �����뵽��ʱ�䣺";
			cin >> time;

			// �ж�����������Ƿ�Ϸ�
			if (isNumberFalse(number)) continue;

			// �ж������ʱ���Ƿ�����
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
			cout << "(!-_-) �����복�ƺ�:";
			cin >> number;

			// �ж�����������Ƿ�Ϸ�
			if (isNumberFalse(number)) continue;

			if (parking.isInParking(number))
			{
				Car car = parking.findByNumber(number);

				int leaveTime;
				cout << "(!-_-) �������뿪ʱ�䣺";
				cin >> leaveTime;

				// �ж�����������Ƿ�Ϸ�
				if (isNumberFalse(number)) continue;

				// �ж������ʱ���Ƿ�����
				if (isTimeFalse(leaveTime, arriveTime)) continue;

				car.leave(parking, tempParking, pavement, car);
				car.setLeaveTime(leaveTime);
				car.setCost();

				cout << endl;
				cout << "*** Ӧ�����Ϊ��" << car.getCost() <<"Ԫ ***"<<endl;
				cout << endl;
				// �����ʱ����г����򽫱����һ��������ͣ������
				if (!pavement.isEmpty())
				{
					Car tempCar;
					pavement.pop(tempCar);

					// ��һ�������뿪ʱ������һ�����Ľ���ʱ��
					tempCar.setArriveTime(leaveTime);

					parking.push(tempCar);

					cout << "### ��ʱ����ϳ��ƺ�Ϊ" << tempCar.getNumber() << "�ĳ�ͣ��ͣ���� ###" << endl;
					cout << "### ͣ��ʱ��Ϊ��" << tempCar.getArriveTime()<<" ###"<<endl;
					cout << endl;
				}
			}
			else if (pavement.isInPavement(number))
			{
				cout << "!!! ERROR:��ĳ�������ʱ����ϣ������뿪 !!!" << endl;
			}
			else
			{
				cout << "!!! ERROR:ͣ������û�������� !!!" << endl;
			}

			break;
		}

		case '!': { status = false; }
		default:
		{
			cout << endl;
			cout << "!!! ERROR:�޴�ѡ��,�����²��� !!!" << endl;
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
		cout << "!!! ERROR:�����ʱ��Ӧ�ô�����һ�����ĵ���ʱ�� !!!" << endl;
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


