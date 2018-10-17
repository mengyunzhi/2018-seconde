#ifndef _Parking
#define _Parking
#define MaxSize 2
#include "Car.h"
class Car;
class Parking
{
public:
	Parking();					  // 构造函数，实例化Parking对象时将构造一个大小为MaxSize大小的Car类对象数组
	~Parking();					  // 析构函数
	bool push(Car & newData);	  // 入栈
	bool pop(Car & data);		  // 出栈
	void display();				  // 输出栈
	bool isFull();				  // 判断栈是否满
	bool isEmpty();				  // 判断栈是否为空
	int getTop();				  // 获取栈顶位置
	int findPosition(int number); // 根据车牌号查询该车在停车场中的位置,失败返回0
	bool isInParking(int number); // 根据车牌号判断该车是否在停车场中
	Car findByNumber(int number); // 根据车牌号查询，成功则返回该车
private:
	Car data[MaxSize];					  // 数据成员将在构造函数执行时进行构造
	int length;					  // 栈长
	int top;					  // 指向栈顶
};
#endif

