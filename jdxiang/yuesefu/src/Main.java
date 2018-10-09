import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        LinearImpl imp = new LinearImpl();
        int P = sc.nextInt();
        int t = sc.nextInt();
        imp.init(P);
        imp.getRing(t);
    }
}
