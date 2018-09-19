package com.company;

import java.awt.*;
import java.awt.geom.Ellipse2D;

/**
 * @author liyiheng
 * @date 2018/9/18 20:13
 */
class AlgoVisHelper {
    private AlgoVisHelper() {

    }

    static void setStrokeWidth(Graphics2D graphics2D, int w) {
        graphics2D.setStroke(new BasicStroke(w, BasicStroke.CAP_ROUND, BasicStroke.JOIN_ROUND));
    }

    public static void storkeCircle(Graphics2D graphics2D, int x, int y, int r) {
        Ellipse2D circle = new Ellipse2D.Double(x - r, y - r, 2 * r, 2 * r);
        graphics2D.draw(circle);
    }

    public static void setColor(Graphics2D graphics2D, Color color) {
        graphics2D.setColor(color);
    }

    public static void pause(int t) {
        try {
            Thread.sleep(t);
        } catch (InterruptedException e) {
            System.out.println("Error in sleep");
        }

    }
}
