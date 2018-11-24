<?php
namespace app\common\model;
use think\Model;
/**
 * 班级
 */
class KlassCourse extends Model
{
    private $KlassCourse;

    /**
     * 获取对应的课程信息
     * @return KlassCourse 课程
     * @author <panjie@yunzhiclub.com> http://www.mengyunzhi.com
     */

    public function KlassCourse()
    {
        return $this->belongsTo('KlassCourse');
    }

    /**
     * 一对多关联
     * @author 梦云智 http://www.mengyunzhi.com
     * @DateTime 2016-10-24T16:27:05+0800
     */
    public function KlassCourses()
    {
        return $this->hasMany('KlassCourse');
    }
}