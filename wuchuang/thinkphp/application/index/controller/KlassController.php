<?php
namespace app\index\controller;
use app\common\model\Klass;        // 班级
class KlassController extends IndexController
{
    public function index()
    {
        //获取查询信息
        $name = input('get.name');

        $pageSize = 2;  //每页显示2条数据

    	$Klass = new Klass;

        //定制查询信息
        if (!empty($name)) {
            $Klass->where('name', 'like', '%' . $name . '%');
        }

        //按条件查询数据并分页
        $klasses = $Klass->paginate($pageSize, false, [
            'query'=>[
            'name' => $name,
            ],
        ]);
        $this->assign('klasses', $klasses);
        return $this->fetch();
    }
    public function add() 
    {
    	return $this->fetch();
    }

    public function save()
    {
    	var_dump(Request::instance()->post());
    }
}