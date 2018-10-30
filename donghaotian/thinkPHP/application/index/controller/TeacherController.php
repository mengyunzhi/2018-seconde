<?php
namespace app\index\controller; // 该文件的位于application\index\controller文件夹
use think\Controller;			// 用于与V层进行数据传递
use app\common\model\Teacher;	// 教师模型
use think\Request;	// 引用Request
/**
 * 教师管理，继承think\Controller后，就可以利用V层对数据进行打包了。
 */
class TeacherController extends Controller
{
	public function index()
	{
		$Teacher = new Teacher;
		$teachers = $Teacher->select();

		// 向V层传数据
		$this->assign('teachers', $teachers);

		// 取回打包后的数据
		$htmls = $this->fetch();

		// 将数据返回给用户
		return $htmls;
	}
	/**
	 * 插入新数据
	 * @return  html
	 * @author  梦云智 http://www.mengyunzhi.com
	 * @date_time_set() 2016-11-0T12:31:24+0800
	 */
	public function insert()
    {
        // 接收传入数据
        $postData = Request()->post();

        // 实例化Teacher空对象
        $Teacher = new Teacher();

        // 为对象赋值
        $Teacher->name = $postData['name'];
        $Teacher->username = $postData['username'];
        $Teacher->sex = $postData['sex'];
        $Teacher->email = $postData['email'];
        

        // 新增对象至数据表
        $Teacher->save();

        // 反馈结果
        return '新增成功。新增ID为：' . $Teacher->id;
    }

    /**
     * 新增数据交互
     * @author 梦云智 http://www.mengyunzhi.com
     * @DateTime 2016-11-07T12:41:23+0800
     */
    public function add()
    {
        $htmls = $this->fetch();
        return $htmls;
    }
}