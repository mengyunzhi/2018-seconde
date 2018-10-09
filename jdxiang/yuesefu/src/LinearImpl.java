public class LinearImpl implements Linear {
    private Node headNode;
    private Node tailNode;
    @Override
    public Node init(int N) {
        if ( N <= 0) {return null;}
        headNode = new Node();
        headNode.data = 1;
        if (N == 1) {
            tailNode = headNode;
            headNode.next  = headNode;
            return headNode;
        }
        Node tempNode = headNode;
        for (int i = 2; i <= N; i++) {
            Node node = new Node();
            node.data = i;
            tempNode.next = node;
            tempNode = node;
        }
        tailNode = tempNode;
        tempNode.next = headNode;
        return headNode;
    }

    @Override
    public void delete(int index) {
        Node temp = headNode;
        Node fron = null;
        if (headNode.next == headNode) {
            headNode.next = null;
            tailNode = null;
            headNode = null;
            return;
        }
        if (headNode.next != null) {
            if (headNode.next.next == headNode) {
                if (headNode.data == index) {
                   headNode = headNode.next;
                   headNode.next = headNode;
                   return;
                }
                if (headNode.next.data == index) {
                    headNode.next = headNode;
                    return;
                }
            }
        }
        if (headNode.data == index) {
            tailNode.next = headNode.next;
            headNode = headNode.next;
            return;
        }
        while(temp.next != headNode) {
            fron = temp;
            temp = temp.next;
            if (temp.data == index) {
                if (temp.data == tailNode.data) {
                    tailNode = fron;
                    tailNode.next = headNode;
                } else {
                    fron.next = temp.next;
                }
                return;
            }
        }
        return;
    }

    @Override
    public void getRing(int p) {
        if (p == 0) {return;}
        int i = 1;
        Node next = headNode;
        while(next != null) {
            if (i % p == 0) {
                System.out.print(next.data);
                delete(next.data);
                if (next.next != null) {
                    System.out.print(" ");
                }
            }
            i++;
            next = next.next;
        }
        return ;
    }
}
