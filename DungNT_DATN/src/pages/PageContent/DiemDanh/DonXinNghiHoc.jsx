import { Button, DatePicker, Input, Select } from "antd"
import dayjs from "dayjs"
import { useEffect, useState } from "react"
import { useDispatch, useSelector } from "react-redux";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import { diemDanhState, getListCaHocAction, xinNghiAction } from "../../../reducers/diemDanhReducer/diemDanhReducer";
const { TextArea } = Input;

export default function DonXinNghiHoc(props) {
    const [ngayHoc, setNgayHoc] = useState(dayjs())
    const [caHoc, setCaHoc] = useState("")
    const [lyDo, setLyDo] = useState("")
    const { userInfo } = useSelector(globalState)
    const { listCaHoc } = useSelector(diemDanhState)
    const dispatch = useDispatch()
    useEffect(() => {
        dispatch(getListCaHocAction())
    }, [])
    const submitForm = () => {
        const data = {
            username: userInfo?.username,
            caHocId: caHoc,
            ngayHoc: ngayHoc.format('YYYY-MM-DD'),
            lyDo: lyDo,
            trangThai: lyDo !== "" ? 1 : 2
        }

        dispatch(xinNghiAction(data))
    }
    return (
        <div className="py-3">
            <div className="mt-5">
                <div> <span>Ngày học</span></div>

                <DatePicker format={"DD/MM/YYYY"} className="w-full" value={ngayHoc} onChange={(e) => {
                    setNgayHoc(dayjs(e))
                }} />
            </div>

            <div className="mt-4">
                <div> <span>Ca học</span></div>
                <Select className="w-full" value={caHoc} options={listCaHoc} onChange={(e) => setCaHoc(e)} />
            </div>

            <div className="mt-4">
                <div> <span>Lý do</span></div>
                <TextArea className="w-full" rows={4} value={lyDo} onChange={(e) => setLyDo(e.target.value)} />
            </div>

            <div className="mt-5 text-center">
                <Button type="primary" onClick={submitForm}>Gửi đơn</Button>
            </div>
        </div>
    )
}