<?php
namespace app\index\controller;
use think\Controller;
use app\common\model\NewTeacher;

class NewIndexController extends Controller
{
	public function __construct()
    {
        parent::__construct();
        if (!NewTeacher::isLogin()) {
            return $this->error('plz login first', url('NewLogin/index'));
        }
    }
    public function index()
    {

    }
}
