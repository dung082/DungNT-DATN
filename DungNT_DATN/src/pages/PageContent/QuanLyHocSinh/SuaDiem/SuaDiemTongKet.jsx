import { Button, Checkbox, Input, Popconfirm, Select } from "antd";
import { useDispatch, useSelector } from "react-redux";
import { getDiemTongKetUserAction, getListKyHocAction, getListMonTongKetAction, quanLyHocSinhState, setDiem, setDiemObject, setKyHoc, setKyThi, setListKyHoc, setListKyThi, setListMonHoc, setMonHoc, setNamHoc, setUsername } from "../../../../reducers/quanLyHocSinhReducer/quanLyHocSinhReducer";
import { useEffect, useState } from "react";
import { suaDiemTongKetAction } from "../../../../reducers/diemTongKetReducer/diemTongKetReducer";

export default function SuaDiemTongKet(props) {

    const { username, namhoc, kyhoc, listKyHoc, listMon, monhoc, diemObject, diem } = useSelector(quanLyHocSinhState)

    const [type, setType] = useState(false)

    useEffect(() => {
        dispatch(setUsername(""))
        dispatch(setNamHoc(""))
        dispatch(setKyHoc(""))
        dispatch(setKyThi(""))
        dispatch(setMonHoc(""))
        dispatch(setListKyHoc([]))
        dispatch(setListKyThi([]))
        dispatch(setListMonHoc([]))
        dispatch(setDiem(0))
        dispatch(setDiemObject(null))

    }, [])

    const dispatch = useDispatch()
    const namHocOptions = [
        {
            label: "2024-2025",
            value: "2024-2025"
        },
        {
            label: "2023-2024",
            value: "2023-2024"
        },
        {
            label: "2022-2023",
            value: "2022-2023"
        },
    ]
    return (
        <div>
            <div className="grid grid-cols-2">
                <div className="p-2">
                    <span>Tài khoản người dùng</span>
                    <Input value={username} onChange={(e) => {
                        dispatch(setUsername(e.target.value))
                    }} />
                </div>

                <div className="p-2">
                    <span>Năm học</span>
                    <Select className="w-full" options={namHocOptions} value={namhoc} onChange={(e) => {
                        dispatch(setNamHoc(e))
                        dispatch(getListMonTongKetAction())
                        dispatch(getListKyHocAction(e))
                    }} />
                </div>

                <div className="p-2">
                    <span>Kỳ học</span>
                    <Select className="w-full" value={kyhoc} options={listKyHoc} onChange={(e) => { dispatch(setKyHoc(e)) }} />
                </div>

                <div className="p-2">
                    <span>Môn tổng kết</span>
                    <Select className="w-full" value={monhoc} options={listMon} onChange={(e) => { dispatch(setMonHoc(e)) }} />
                </div>
            </div>

            <div className="text-center mt-3">
                <Button
                    type="primary"
                    onClick={() => {
                        dispatch(getDiemTongKetUserAction(username, monhoc, kyhoc))
                    }}
                >Tra cứu</Button>
            </div>

            <div className="mt-3">
                {
                    diem ? (
                        <div>
                            <div className="grid grid-cols-2 items-end">
                                <div className="p-2">
                                    <span>Điểm tổng kết</span>
                                    <Input
                                        value={diem}
                                        onChange={(e) => {
                                            dispatch(setDiem(e.target.value));
                                        }}
                                    />
                                </div>

                                <div className="p-2">
                                    <Checkbox checked={type} onChange={(e) => {
                                        setType(e.target.checked)
                                    }}>
                                        Sửa theo đơn phúc khảo của học sinh
                                    </Checkbox>
                                </div>
                            </div>
                            <div className="text-center mt-3">

                                <Popconfirm
                                    className="ml-3"
                                    title="Sửa điểm tổng kết"
                                    description="Bạn có chắc chắn muốn sửa điểm tổng kết?"
                                    onConfirm={() => {
                                        dispatch(suaDiemTongKetAction(type ? 1 : 0, diemObject?.id, diem))
                                    }}
                                    //   onCancel={cancel}
                                    okText="Sửa điểm"
                                    cancelText="hủy"
                                >
                                    <Button type="primary" >Sửa điểm</Button>
                                </Popconfirm>

                            </div>
                        </div>
                    ) : (
                        <div></div>
                    )
                }
            </div>
        </div>
    )
}