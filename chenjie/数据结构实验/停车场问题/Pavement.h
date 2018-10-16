#ifndef _Pavement
#define _Pavement
#define NULL 0
#include "Car.h"

class Car;
struct NODE                       // ˫�����������Ԫ�ṹ
{
	Car *data;					  // ���ݳ�Ա����Pavement�๹�캯��ִ��ʱ���г�ʼ��
	NODE *next;					  // ���ָ��
	NODE *pre;					  // ǰ��ָ��
};
class Pavement                    // ��ʱ���
{
public:
	Pavement();					  // ���캯��
	~Pavement();				  // ��������
	void initialize();			  // ��ʼ�����ڹ��캯�������
	void push(Car & newData);	  // ���
	bool pop(Car & newData);	  // ����				
	void display();				  // �������
	bool isEmpty();				  // �ж��Ƿ�Ϊ��
	int findPosition(int number); // ���ݳ��ƺŲ��Ҹó�����ʱ�����λ�ã�ʧ���򷵻�0
	bool isInPavement(int number);// ���ݳ��ƺ��жϸó��Ƿ�����ʱ�����
	Car findByNumber(int number);
private:
	NODE *front;				  // ��ͷָ��
	NODE *tail;					  // ��βָ��
	int size;					  // �ӳ�

};
#endif

