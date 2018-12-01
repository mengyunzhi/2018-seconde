#include "HuffmanTree.h"

HuffmanTree::HuffmanTree(int leaf_number)
{
	this->leaf_number = leaf_number;
	// 数组第一个元素为空，从下标1开始存储
	Node nullNode;
	huTree.push_back(nullNode);

	// 读入字符和权，作为哈夫曼树的叶子节点
	for (int i = 0; i < leaf_number; i++) {
		char code;
		int weight;
		scanf("%c, %d,",&code,&weight);
		Node node(code, weight);
		huTree.push_back(node);
	}
}

void HuffmanTree::generateHuCode()
{
	for (size_t i = 0; i < leaf_number - 1; i++)
	{
		// 寻找哈夫曼树中权值最小的两个节点的位置
		int mPos1 = findMinLeaf();
		int mPos2 = findMinLeaf();

		// 将这两个权最小的节点的父节点置为新节点
		huTree[mPos1].parent = huTree[mPos2].parent = huTree.size();

		// 新建一个节点作为父节点
		Node parentNode;
		// 将两个最小节点的位置作为父节点的左右孩子
		parentNode.lchild = mPos1;
		parentNode.rchild = mPos2;
		// 将左右孩子节点的权重和作为父节点的权重
		parentNode.weight = huTree[mPos1].weight + huTree[mPos2].weight;

		// 将父节点存到哈夫曼树当中
		huTree.push_back(parentNode);
	}
}

void HuffmanTree::saveHuTree()
{
	ofstream hfmTree;
	// 打开文件
	hfmTree.open("hfmTree.txt", ios::in | ios::trunc);
	// 读写文件
	if (hfmTree.is_open())
	{
		// 表头
		hfmTree << "position\tdata\tweight\tparent\tlchild\trchild\n";
		// 表内容
		for (int i = 1; i < huTree.size(); i++) {
			hfmTree << i << "\t";
			hfmTree << huTree[i].code << "\t";
			hfmTree << huTree[i].weight << "\t";
			hfmTree << huTree[i].parent << "\t";
			hfmTree << huTree[i].lchild << "\t";
			hfmTree << huTree[i].rchild << "\t" << "\n";
		}
		hfmTree.close();
	}
}

void HuffmanTree::saveHuCode()
{
	ofstream hfmTree;
	// 打开文件
	hfmTree.open("hfmCode.txt", ios::in | ios::trunc);
	// 读写文件
	if (hfmTree.is_open())
	{
		map<char, string>::iterator it;
		for (it = huCode.begin(); it != huCode.end(); it++)
			hfmTree << (*it).first << ":" << (*it).second << "\n";
		hfmTree.close();
	}
}

void HuffmanTree::enCoding()
{
	for (int i = 1; i <= leaf_number; i++)
	{
		// 寻找叶子节点的父节点位置
		int leaf = i;
		int parent = huTree[i].parent;
		string code;
		// 从叶子节点出发，寻找根节点，左为0，右为1
		while (parent) {
			if (huTree[parent].lchild == leaf) {
				code += '0';
			} else {
				code += '1';
			}
			leaf = parent;
			parent = huTree[parent].parent;		
		}
		// 将编码逆置调整
		reverse(code.begin(), code.end());
		// 存储哈夫曼编码
		huCode[huTree[i].code] = code;
	}
}

void HuffmanTree::codeing()
{
	ifstream ToBeTran;
	string input;
	string output;
	// 打开文件
	ToBeTran.open("ToBeTran.txt");
	// 读文件
	if (ToBeTran.is_open()) {
		getline(ToBeTran, input);
		// 获取对应的编码，存放到output中
		for (int i = 0; i < input.size(); i++) {
			output += huCode[input[i]];
		}
		// 关闭文件
		ToBeTran.close();
	}

	// 打开文件
	ofstream CodeFile;
	CodeFile.open("CodeFile.txt", ios::in | ios::trunc);
	if (CodeFile.is_open()) {
		// 将编码结果写入文件
		CodeFile << output;
		// 关闭文件
		CodeFile.close();
	}
	// 打印编码结果
	for (int i = 0; i < output.size(); i++){
		// 每50个字符换行
		if (i%50 == 0 && i >= 50){
			cout << '\n';
		}
		cout << output[i];
	}
	cout << endl;
}

void HuffmanTree::deCoding()
{
	ifstream CodeFile;
	string input;
	string output;
	int start = 0;
	int length = 1;
	// 打开文件
	CodeFile.open("CodeFile.txt");
	// 读文件
	if (CodeFile.is_open()) {
		CodeFile >> input;
		// 获取对应的编码，存放到output中
		for (int i = 0; i < input.size(); i++) {
			string sub = input.substr(start, length);
			char key = '0';
			if (findKeyByValue(sub, key)) {
				output += key;
				start = i + 1;
				length = 1;
			}
			else { length++; }
		}
		// 关闭文件
		CodeFile.close();
	}

	// 打开文件
	ofstream TextFile;
	TextFile.open("TextFile.txt", ios::in | ios::trunc);
	if (TextFile.is_open()) {
		// 将编码结果写入文件
		TextFile << output;
		// 关闭文件
		TextFile.close();
	}
}

int HuffmanTree::findMinLeaf()
{
	int min = 999;
	int position = 999;
	// 将第一个叶子节点的权和位置作为权值最小的权和位置
	for (int i = 1; i < huTree.size() && huTree[i].parent == 0; i++)
	{
		min = huTree[1].weight;
		position = 1;
	}

	for (int i = 2; i < huTree.size(); i++) {
		// 当节点的权值小于最小的权值且无父节点（叶子节点）时
		// 将此节点的权作为最小权，并保存该节点的位置
		if (huTree[i].weight < min && huTree[i].parent == 0) {
			min = huTree[i].weight;
			position = i;
		}
	}
	// 将最小节点的父节点赋值为-1，作为已被搜索的标志
	huTree[position].parent = -1;
	// 返回最小节点的位置
	return position;
}

void HuffmanTree::treePrinting(int & postion, string str)
{
	if (huTree[postion].weight == 0) {
		return;
	}
	str += "   ";
	treePrinting(huTree[postion].rchild, str);
	cout << str << huTree[postion].weight<<endl;
	treePrinting(huTree[postion].lchild, str);
}

bool HuffmanTree::findKeyByValue(string value, char & key)
{
	// 定义一个map迭代器，用来查询map
	std::map<char, string>::iterator it;
	// 根据value查询map的key
	for (it = huCode.begin(); it != huCode.end(); ++it) {
		// 成功得到key，返回true，失败返回false
		if (it->second == value) {
			key = it->first;
			return true;
		}
	}
	return false;
}
