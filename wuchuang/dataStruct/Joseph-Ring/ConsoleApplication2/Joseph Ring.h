#include <iostream>
using namespace std;
typedef int ElemType;
struct NodeType
{
	ElemType data;										//�������
	ElemType order;										//���˳��
	NodeType *next;
};
class Clist
{
	NodeType *p;									//ָ�����λ��ڵ�
	NodeType *q;									//ָ��p��ǰ�����
	int length;
public:
	Clist()											//���캯���������׽ڵ�
	{
		p = new NodeType;
		p->next = p;
		length = 1;
	}

	void createBackward()							//����������������			
	{
		NodeType *r, *s;
		r = p;
		cout << "��������:" << endl;
		cin >> length;
		for (int i = 0; i < length; i++)
		{
			if (i == 0)								//�����һ���ڵ������
			{
				cout << "�����1���˵�����:";
				cin >> p->data;
				p->order = i + 1;
			}
			else
			{
				s = new NodeType;						//���δ���ʣ�½ڵ������
				cout << "�����" << i + 1 << "���˵�����:";
				cin >> s->data;
				s->order = i + 1;
				s->next = r->next;
				r->next = s;
				r = r->next;
			}
		}
	}

	int getLength()									//��ȡ����ĳ���
	{
		return length;
	}

	int showOrder(int i)							//���λ�򲢷���
	{
		for (int j = 1; j < i; j++)
		{
			q = p;
			p = p->next;
		}
		return p->order;
	}

	int getData()									//��ȡ���λ�������
	{
		return p->data;
	}

	void deleteNode() {								//ɾ�����λ��Ľڵ�
		q->next = p->next;
		delete p;
		p = q->next;
		length--;
	}
};
