#include <iostream>
#include <string>
#include "AMLGraph.h"
using namespace std;
int main()
{
	AMLGraph amlGraph;
	int toBeSearched;
	amlGraph.init();
	cout << "����Ҫ�����Ķ���:";
	cin >> toBeSearched;
	// �����������
	amlGraph.printDFSSe(toBeSearched);
	// ���ø�������״̬
	amlGraph.resetVisited();
	// �����������
	amlGraph.Breadth_First_Search(toBeSearched);
	return 0;
}