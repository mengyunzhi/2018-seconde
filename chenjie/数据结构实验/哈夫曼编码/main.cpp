#include <iostream>
#include "HuffmanTree.h"
using namespace std;
int main()
{ 
	// ��ʼ����������
	HuffmanTree huffmanTree(27);
	// ���ɹ�������
	huffmanTree.generateHuCode();
	// ���ɹ���������
	huffmanTree.enCoding();
	// ������������͹��������뵽�ļ���
	huffmanTree.saveHuTree();
	huffmanTree.saveHuCode();
	// ����
	huffmanTree.codeing();
	// ����
	huffmanTree.deCoding();
	// �԰���������������
	int a = 53;
	string str;
	huffmanTree.treePrinting(a, str);
	return 0;
}