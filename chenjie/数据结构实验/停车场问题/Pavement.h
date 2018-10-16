#ifndef _Pavement
#define _Pavement
#define NULL 0
#include "Car.h"

class Car;
struct NODE                       // 双向链表基本单元结构
{
	Car *data;					  // 数据成员将在Pavement类构造函数执行时进行初始化
	NODE *next;					  // 后继指针
	NODE *pre;					  // 前驱指针
};
class Pavement                    // 临时便道
{
public:
	Pavement();					  // 构造函数
	~Pavement();				  // 析构函数
	void initialize();			  // 初始化将在构造函数里进行
	void push(Car & newData);	  // 入队
	bool pop(Car & newData);	  // 出队				
	void display();				  // 输出队列
	bool isEmpty();				  // 判断是否为空
	int findPosition(int number); // 根据车牌号查找该车在临时便道的位置，失败则返回0
	bool isInPavement(int number);// 根据车牌号判断该车是否在临时便道中
	Car findByNumber(int number);
private:
	NODE *front;				  // 队头指针
	NODE *tail;					  // 队尾指针
	int size;					  // 队长

};
#endif

