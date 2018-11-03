#include "Customer.h"
#include "Queue.h"
#include "Window.h"
#include "Menu.h"
#include <iostream>
using namespace std;
int main()
{
	Menu menu;
	Queue queue;
	Window windows[MaxSize];

	menu.cinArriveAndHandleTime(queue);
	menu.cinWindowsNumber();
	menu.StartWork(queue, windows);
	menu.coutAverageAndMaxAndFinalTime();
	menu.coutServiceNumber(windows);

	return 0;
}