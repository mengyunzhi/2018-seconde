#ifndef _Parking
#define _Parking
#define MaxSize 2
#include "Car.h"
class Car;
class Parking
{
public:
	Parking();					  // ���캯����ʵ����Parking����ʱ������һ����СΪMaxSize��С��Car���������
	~Parking();					  // ��������
	bool push(Car & newData);	  // ��ջ
	bool pop(Car & data);		  // ��ջ
	void display();				  // ���ջ
	bool isFull();				  // �ж�ջ�Ƿ���
	bool isEmpty();				  // �ж�ջ�Ƿ�Ϊ��
	int getTop();				  // ��ȡջ��λ��
	int findPosition(int number); // ���ݳ��ƺŲ�ѯ�ó���ͣ�����е�λ��,ʧ�ܷ���0
	bool isInParking(int number); // ���ݳ��ƺ��жϸó��Ƿ���ͣ������
	Car findByNumber(int number); // ���ݳ��ƺŲ�ѯ���ɹ��򷵻ظó�
private:
	Car data[MaxSize];					  // ���ݳ�Ա���ڹ��캯��ִ��ʱ���й���
	int length;					  // ջ��
	int top;					  // ָ��ջ��
};
#endif

