#include <iostream>
#include <string>
#include "AMLGraph.h"
using namespace std;
int main()
{
	AMLGraph amlGraph;
	int toBeSearched;
	amlGraph.init();
	cout << "输入要搜索的顶点:";
	cin >> toBeSearched;
	// 深度优先搜索
	amlGraph.printDFSSe(toBeSearched);
	// 重置各点搜索状态
	amlGraph.resetVisited();
	// 广度优先搜索
	amlGraph.Breadth_First_Search(toBeSearched);
	return 0;
}