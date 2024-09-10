import { Button, Checkbox, DatePicker, Input, Select } from "antd"
import dayjs from "dayjs"
import { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { diemDanhListAction, diemDanhState, getListCaHocAction, getListHocSinhAction, getListLopHocAction, layDiemDanhAction, setCaHoc, setListHocSinh, setLopHoc, setNgayHoc } from "../../../reducers/diemDanhReducer/diemDanhReducer"
import { openDrawerAction } from "../../../reducers/drawerReducer/drawerReducer"
import DuyetXinNghiHS from "./DuyetXinNghiHS"
import { cloneDeep } from "lodash"

export default function DiemDanhHocSinh(props) {

    const dispatch = useDispatch()
    const { listCaHoc, cahoc, ngayHoc, namhoc, lopHoc, listLopHoc, listHocSinh } = useSelector(diemDanhState)
    useEffect(() => {
        dispatch(getListCaHocAction())
        dispatch(layDiemDanhAction(0))
        dispatch(getListLopHocAction())
    }, [])

    useEffect(() => {
        console.log(listHocSinh)
    }, [listHocSinh])

    return (
        <div className="p-3">
            <div className=" bottem-border-title pb-2">
                <div className="flex justify-between">
                    <div>
                        <span className="font-bold text-xl">Điểm danh</span>
                    </div>
                    <div>
                        {/* <Button type="primary" onClick={openDrawerEditUser}>
            Sửa thông tin
          </Button> */}
                    </div>
                </div>
            </div>
            <div className="mt-3 flex justify-between px-5">
                <div className="flex items-end">
                    <div className="ml-2 w-[200px]">
                        <span>Ngày học</span>
                        <DatePicker className="w-full"
                            format={"DD/MM/YYYY"}
                            value={ngayHoc}
                            onChange={(e) => {
                                dispatch(setNgayHoc(dayjs(e)))
                            }}
                        />
                    </div>

                    <div className="ml-2 w-[200px]">
                        <span>Lớp học</span>
                        <Select className="w-full" value={lopHoc} options={listLopHoc} onChange={(e) => {
                            dispatch(setLopHoc(e))
                        }} />
                    </div>

                    <div className="ml-2 w-[200px]">
                        <span>Ca học</span>
                        <Select className="w-full" options={listCaHoc} value={cahoc} onChange={(e) => {
                            dispatch(setCaHoc(e))
                        }} />
                    </div>

                    <Button type="primary" className="ml-2" onClick={() => {
                        console.log(dayjs(ngayHoc).get('month'))
                        let namhc = ""
                        if (dayjs(ngayHoc).get('month') < 8) {
                            namhc = `${dayjs(ngayHoc).get('year') - 1}-${dayjs(ngayHoc).get('year')}`
                        }
                        else {
                            namhc = `${dayjs(ngayHoc).get('year')}-${dayjs(ngayHoc).get('year') + 1}`
                        }
                        dispatch(getListHocSinhAction(namhc, lopHoc))
                    }}>Lấy danh sách lớp</Button>
                </div>
                <div className="p-5">
                    <Button type="primary" onClick={() => {
                        dispatch(openDrawerAction({
                            title: "Duyệt điểm danh",
                            DrawerComponent: <DuyetXinNghiHS />
                        }))
                    }}>Duyệt điểm danh</Button>
                </div>
            </div>
            <div className="mt-5 px-5">
                {
                    listHocSinh?.length > 0 && (
                        <div>
                            <table className="w-full dungnt-custom-table">
                                <thead>
                                    <tr>
                                        <th className="w-[50px]">STT</th>
                                        <th>Tên tài khoản</th>
                                        <th>Họ và tên</th>
                                        <th>Có mặt</th>
                                        <th>Nghỉ có phép</th>
                                        <th>Nghỉ không phép</th>
                                        <th>Đi muộn</th>
                                        <th>Lý do</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {listHocSinh?.map((item, index) => {
                                        return (
                                            <tr key={index}>
                                                <td>{index + 1}</td>
                                                <td>{item?.username}</td>
                                                <td>{item?.hoTen}</td>
                                                <td><Checkbox onChange={(e) => {
                                                    let newList = cloneDeep(listHocSinh)
                                                    newList[index].trangThai = 1
                                                    dispatch(setListHocSinh([...newList]))
                                                }} checked={item?.trangThai === 1}></Checkbox></td>
                                                <td><Checkbox onChange={(e) => {
                                                    let newList = cloneDeep(listHocSinh)
                                                    newList[index].trangThai = 2
                                                    dispatch(setListHocSinh([...newList]))
                                                }} checked={item?.trangThai === 2}></Checkbox></td>
                                                <td><Checkbox onChange={(e) => {
                                                    let newList = cloneDeep(listHocSinh)
                                                    newList[index].trangThai = 3
                                                    dispatch(setListHocSinh([...newList]))
                                                }} checked={item?.trangThai === 3}></Checkbox></td>
                                                <td><Checkbox onChange={(e) => {
                                                    let newList = cloneDeep(listHocSinh)
                                                    newList[index].trangThai = 4
                                                    dispatch(setListHocSinh([...newList]))
                                                }} checked={item?.trangThai === 4}></Checkbox></td>
                                                <td><Input value={item?.lyDo} onChange={(e) => {
                                                    let newList = cloneDeep(listHocSinh)
                                                    newList[index].lyDo = e.target.value
                                                    dispatch(setListHocSinh([...newList]))
                                                }} /></td>
                                            </tr>
                                        )
                                    })}
                                </tbody>
                            </table>
                            <div className="mt-5 text-center">
                                <Button type="primary" onClick={() => {
                                    const data = {
                                        caHocId: cahoc,
                                        ngayHoc: ngayHoc.format("YYYY-MM-DD"),
                                        lstDiemDanhHS: listHocSinh?.map(item => {
                                            return {
                                                username: item?.username,
                                                trangThai: item?.trangThai,
                                                lyDo: item?.lyDo
                                            }
                                        })
                                    }
                                    dispatch(diemDanhListAction(data))
                                }}> Nộp đơn điểm danh</Button>
                            </div>
                        </div>
                    )
                }
            </div>
        </div>
    )
}