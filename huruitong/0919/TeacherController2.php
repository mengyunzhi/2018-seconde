<?php
namespace app\index\controller;
use app\common\model\Teacher;

class TeacherController
{
    public function index()
    {
        $JiaoShiBiao = new Teacher;
        $SuoYouJiaoShi = $JiaoShiBiao->select();
        $JiaoShiZhangSan = $SuoYouJiaoShi[0];
        echo "教师姓名" . $JiaoShiZhangSan->getData('name') . '<br />';
        return '重复一遍：教师姓名' . $JiaoShiZhangSan->getData('name');
    }
}
