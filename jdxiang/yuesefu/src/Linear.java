public interface Linear {
    //初始化一个长度为N的循环链表并返回头结点
    Node init(int N);
    //删除循环链表中索引为index的元素
    void delete(int index);
    //输出约瑟夫环
    void getRing(int p);
}
