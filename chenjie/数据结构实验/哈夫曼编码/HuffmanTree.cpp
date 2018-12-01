#include "HuffmanTree.h"

HuffmanTree::HuffmanTree(int leaf_number)
{
	this->leaf_number = leaf_number;
	// �����һ��Ԫ��Ϊ�գ����±�1��ʼ�洢
	Node nullNode;
	huTree.push_back(nullNode);

	// �����ַ���Ȩ����Ϊ����������Ҷ�ӽڵ�
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
		// Ѱ�ҹ���������Ȩֵ��С�������ڵ��λ��
		int mPos1 = findMinLeaf();
		int mPos2 = findMinLeaf();

		// ��������Ȩ��С�Ľڵ�ĸ��ڵ���Ϊ�½ڵ�
		huTree[mPos1].parent = huTree[mPos2].parent = huTree.size();

		// �½�һ���ڵ���Ϊ���ڵ�
		Node parentNode;
		// ��������С�ڵ��λ����Ϊ���ڵ�����Һ���
		parentNode.lchild = mPos1;
		parentNode.rchild = mPos2;
		// �����Һ��ӽڵ��Ȩ�غ���Ϊ���ڵ��Ȩ��
		parentNode.weight = huTree[mPos1].weight + huTree[mPos2].weight;

		// �����ڵ�浽������������
		huTree.push_back(parentNode);
	}
}

void HuffmanTree::saveHuTree()
{
	ofstream hfmTree;
	// ���ļ�
	hfmTree.open("hfmTree.txt", ios::in | ios::trunc);
	// ��д�ļ�
	if (hfmTree.is_open())
	{
		// ��ͷ
		hfmTree << "position\tdata\tweight\tparent\tlchild\trchild\n";
		// ������
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
	// ���ļ�
	hfmTree.open("hfmCode.txt", ios::in | ios::trunc);
	// ��д�ļ�
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
		// Ѱ��Ҷ�ӽڵ�ĸ��ڵ�λ��
		int leaf = i;
		int parent = huTree[i].parent;
		string code;
		// ��Ҷ�ӽڵ������Ѱ�Ҹ��ڵ㣬��Ϊ0����Ϊ1
		while (parent) {
			if (huTree[parent].lchild == leaf) {
				code += '0';
			} else {
				code += '1';
			}
			leaf = parent;
			parent = huTree[parent].parent;		
		}
		// ���������õ���
		reverse(code.begin(), code.end());
		// �洢����������
		huCode[huTree[i].code] = code;
	}
}

void HuffmanTree::codeing()
{
	ifstream ToBeTran;
	string input;
	string output;
	// ���ļ�
	ToBeTran.open("ToBeTran.txt");
	// ���ļ�
	if (ToBeTran.is_open()) {
		getline(ToBeTran, input);
		// ��ȡ��Ӧ�ı��룬��ŵ�output��
		for (int i = 0; i < input.size(); i++) {
			output += huCode[input[i]];
		}
		// �ر��ļ�
		ToBeTran.close();
	}

	// ���ļ�
	ofstream CodeFile;
	CodeFile.open("CodeFile.txt", ios::in | ios::trunc);
	if (CodeFile.is_open()) {
		// ��������д���ļ�
		CodeFile << output;
		// �ر��ļ�
		CodeFile.close();
	}
	// ��ӡ������
	for (int i = 0; i < output.size(); i++){
		// ÿ50���ַ�����
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
	// ���ļ�
	CodeFile.open("CodeFile.txt");
	// ���ļ�
	if (CodeFile.is_open()) {
		CodeFile >> input;
		// ��ȡ��Ӧ�ı��룬��ŵ�output��
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
		// �ر��ļ�
		CodeFile.close();
	}

	// ���ļ�
	ofstream TextFile;
	TextFile.open("TextFile.txt", ios::in | ios::trunc);
	if (TextFile.is_open()) {
		// ��������д���ļ�
		TextFile << output;
		// �ر��ļ�
		TextFile.close();
	}
}

int HuffmanTree::findMinLeaf()
{
	int min = 999;
	int position = 999;
	// ����һ��Ҷ�ӽڵ��Ȩ��λ����ΪȨֵ��С��Ȩ��λ��
	for (int i = 1; i < huTree.size() && huTree[i].parent == 0; i++)
	{
		min = huTree[1].weight;
		position = 1;
	}

	for (int i = 2; i < huTree.size(); i++) {
		// ���ڵ��ȨֵС����С��Ȩֵ���޸��ڵ㣨Ҷ�ӽڵ㣩ʱ
		// ���˽ڵ��Ȩ��Ϊ��СȨ��������ýڵ��λ��
		if (huTree[i].weight < min && huTree[i].parent == 0) {
			min = huTree[i].weight;
			position = i;
		}
	}
	// ����С�ڵ�ĸ��ڵ㸳ֵΪ-1����Ϊ�ѱ������ı�־
	huTree[position].parent = -1;
	// ������С�ڵ��λ��
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
	// ����һ��map��������������ѯmap
	std::map<char, string>::iterator it;
	// ����value��ѯmap��key
	for (it = huCode.begin(); it != huCode.end(); ++it) {
		// �ɹ��õ�key������true��ʧ�ܷ���false
		if (it->second == value) {
			key = it->first;
			return true;
		}
	}
	return false;
}
