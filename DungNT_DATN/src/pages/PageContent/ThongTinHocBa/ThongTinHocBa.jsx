import { Input, Tabs } from "antd";
import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getHocBaAction, hocBaState } from "../../../reducers/hocBaReducer/hocBaReducer";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import ChiTietHocBa from "./ChiTietHocBa";
import dayjs from "dayjs";
export default function ThongTinHocBa(props) {

  const dispatch = useDispatch()
  const { hocba } = useSelector(hocBaState)
  const { userInfo } = useSelector(globalState)

  useEffect(() => {
    dispatch(getHocBaAction(userInfo?.username, 10))
  }, [])
  const items = [
    {
      key: 10,
      label: 'Lớp 10',
      children: <ChiTietHocBa hocba={hocba} />,
    },
    {
      key: 11,
      label: 'Lớp 11',
      children: <ChiTietHocBa hocba={hocba} />,
    },
    {
      key: 12,
      label: 'Lớp 12',
      children: <ChiTietHocBa hocba={hocba} />,
    },
  ];


  const onChange = (key) => {
    dispatch(getHocBaAction(userInfo?.username, key))
  };


  return (
    <>
      <div className="p-5">
        <div className=" bottem-border-title pb-2">
          <div className="flex justify-between">
            <div>
              <span className="font-bold text-xl">
                Thông tin học bạ
              </span>
            </div>
          </div>
        </div>

        <div className="mt-2">
          <div className="grid grid-cols-3">
            <div className="p-2"><span>Họ và tên : <span className="font-bold">{userInfo?.hoTen}</span></span></div>
            <div className="p-2"><span>Ngày sinh : <span className="font-bold">{dayjs(userInfo?.ngaySinh).format("DD/MM/YYYY")}</span></span></div>
            <div className="p-2"><span>Khóa học: <span className="font-bold">{userInfo?.tenKhoaHoc}</span></span></div>
          </div>
        </div>

        <Tabs defaultActiveKey={10} items={items} onChange={onChange} className="mt-2 tabs-hocba" />

      </div>
    </>
  )
}
