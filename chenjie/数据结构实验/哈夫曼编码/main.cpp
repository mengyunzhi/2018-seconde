#include <iostream>
#include "HuffmanTree.h"
using namespace std;
void menu();
void print();//显示codefile内容
int main()
{
	HuffmanTree huffmanTree;
	bool onOff = true;
	while (onOff)
	{
		menu();
		char option = '0';
		cin >> option;
		switch (option) {
		case 'A': {
			// 初始化哈夫曼树
			huffmanTree.Initialization();
			// 保存哈夫曼树和哈夫曼编码到文件中
			huffmanTree.saveHuTree();
			huffmanTree.saveHuCode();
			break;
		}
		case 'B': { huffmanTree.codeing(); break; } // 编码

		case 'C': { huffmanTree.deCoding(); break; } // 译码
		case 'D': { print(); break; }				// 打印代码文件
		case 'E': {
			// 以凹入表输出哈夫曼树并存到文件中
			ofstream TreePrint;
			TreePrint.open("TreePrint.txt", ios::in | ios::trunc);
			int a = huffmanTree.getLeafNumber() * 2 - 1;
			string str;
			huffmanTree.treePrinting(a, str, TreePrint);
			break;
		}
		case 'Q': { onOff = false; break; }
		}
	}
	return 0;
}

void menu()
{
	cout << "请选择：" << endl;
	cout << "A:初始化\tB:编码\tC:译码\tD:打印代码文件\nE:打印哈夫曼树(凹入表)\tQ:退出" << endl;
}

void print()
{
	ifstream CodeFile;
	ofstream CodePrint;
	// 打开文件
	CodeFile.open("CodeFile.txt");
	CodePrint.open("CodePrint.txt", ios::in | ios::trunc);
	// 读文件
	if (CodeFile.is_open()) {
		string content;
		getline(CodeFile, content);
		for (int i = 0; i < content.size(); i++) {
			if (i % 50 == 0 && i >= 50) {
				CodePrint << '\n';
				cout << endl;
			}
			CodePrint << content[i];
			cout << content[i];
		}
		cout << endl;
		// 关闭文件
		CodeFile.close();
		CodePrint.close();
	}
}
