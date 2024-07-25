import { useDispatch, useSelector } from "react-redux"
import { diemDanhState, getDiemDanhAction } from "../../../reducers/diemDanhReducer/diemDanhReducer"
import { useEffect, useState } from "react"
import { globalState } from "../../../reducers/globalReducer/globalReducer"
import dayjs from "dayjs"
import { Button, DatePicker, Input, Modal, Select } from "antd"
import { openModalAction } from "../../../reducers/modalReducer/modalReducer"
import DonXinNghiHoc from "./DonXinNghiHoc"

export default function DiemDanh(props) {

    const dispatch = useDispatch()
    const { diemDanh } = useSelector(diemDanhState)
    const { userInfo } = useSelector(globalState)
    const [ngay, setNgay] = useState(dayjs())


    useEffect(() => {
        dispatch(getDiemDanhAction("", userInfo?.username))
    }, [])

    return (
        <>
            <div>
                <div
                    className="p-5">
                    <div className=" bottem-border-title pb-2">
                        <div className="flex justify-between">
                            <div>
                                <span className="font-bold text-xl">Điểm danh, xin nghỉ</span>
                            </div>
                        </div>
                    </div>
                    <div className="mt-4">
                        <div className="flex justify-end items-end">
                            <div>
                                <div>
                                    <span>Chọn ngày học</span>
                                </div>
                                <DatePicker
                                    className="w-[200px] "
                                    value={ngay}
                                    format={"DD/MM/YYYY"}
                                    onChange={(e) => {
                                        setNgay(dayjs(e));
                                        dispatch(getDiemDanhAction(e.format('YYYY-MM-DD'), userInfo?.username));
                                    }}
                                    disabledDate={(current) => {
                                        return current && current > dayjs();
                                    }}
                                />
                            </div>

                            <Button
                                type="primary"
                                className="ml-3"
                                onClick={() => {
                                    dispatch(openModalAction({
                                        title: "Đơn xin nghỉ học",
                                        ModalComponent: <DonXinNghiHoc />
                                    }))
                                }}>Xin nghỉ</Button>
                        </div>
                        <table className="w-full table-tkb mt-4">
                            <tr>
                                <th>Ca học</th>
                                {diemDanh?.ngay?.map((item) => {
                                    return (
                                        <th key={Math.random() * 65165}>
                                            <div>
                                                <div>
                                                    {dayjs(item).day() === 0
                                                        ? "Chủ nhật"
                                                        : `Thứ ${dayjs(item).day() + 1}`}
                                                </div>
                                                <div>
                                                    <span>{dayjs(item).format("DD/MM/YYYY")}</span>
                                                </div>
                                            </div>
                                        </th>
                                    );
                                })}
                            </tr>
                            <tr>
                                <td>Ca sáng</td>

                                {diemDanh?.dd?.S?.map((item) => {
                                    if (item === null) {
                                        return (
                                            <td key={Math.random() * 65165}>
                                                <div className="parent flex justify-center items-center" style={{ height: 100 }}>  Không có lịch học</div>
                                            </td>
                                        );
                                    } else {
                                        return (
                                            <td
                                                key={Math.random() * 65165}
                                                title="Xem chi tiết lịch học"
                                            >
                                                <div className="parent flex justify-center items-center" style={{ height: 100 }}>{item?.trangThai === 1 ? "Có mặt" : item?.status === 2 ? "Vắng có phép" : "Vắng không phép"}</div>
                                            </td>
                                        );
                                    }
                                })}

                            </tr>

                            <tr>
                                <td>Ca chiều</td>

                                {diemDanh?.dd?.C?.map((item) => {
                                    if (item === null) {
                                        return (
                                            <td key={Math.random() * 65165}>
                                                <div className="parent flex justify-center items-center" style={{ height: 100 }}> Không có lịch học</div>
                                            </td>
                                        );
                                    } else {
                                        return (
                                            <td
                                                key={Math.random() * 65165}
                                                title="Xem chi tiết lịch học"
                                            >
                                                <div className="parent flex justify-center items-center" style={{ height: 100 }}>{item?.status === 1 ? "Có mặt" : item?.status === 2 ? "Vắng có phép" : "Vắng không phép"}</div>
                                            </td>
                                        );
                                    }
                                })}

                            </tr>

                        </table>
                    </div>
                </div>
            </div>
        </>
    )
}