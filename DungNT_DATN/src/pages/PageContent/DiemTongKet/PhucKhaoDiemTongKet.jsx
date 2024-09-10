import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { diemTongKetState, getListMonTongKetPKAction, phucKhaoDiemTongKetAction, setListMonTongKetPK } from "../../../reducers/diemTongKetReducer/diemTongKetReducer";
import { Button, Checkbox } from "antd";
import { closeModalAction } from "../../../reducers/modalReducer/modalReducer";
import { globalState } from "../../../reducers/globalReducer/globalReducer";

export default function PhucKhaoDiemTongKet(props) {

    const dispatch = useDispatch();

    const { listMonTongKetPK, namHoc, kyHoc } = useSelector(diemTongKetState)
    const { userInfo } = useSelector(globalState)

    useEffect(() => {
        dispatch(getListMonTongKetPKAction())
    }, [])

    return (
        <div>
            <span>Chú ý : Vui lòng chọn các môn thi bạn muốn phúc khảo điểm</span>
            <div className="grid-cols-2 grid mt-3">
                {
                    listMonTongKetPK?.map((item, index) => {
                        return (
                            <div key={index} className="col-span-1 mt-2" >
                                <Checkbox checked={item?.check} onChange={(e) => {
                                    let newList = listMonTongKetPK.map((item) => {
                                        return {
                                            ...item
                                        }
                                    })
                                    newList[index].check = e.target.checked;
                                    console.log(newList)
                                    dispatch(setListMonTongKetPK([...newList]));
                                }}>
                                    {item?.tenMon}
                                </Checkbox>
                            </div>
                        )
                    })
                }
            </div>
            <div className="text-center mt-3">
                <Button onClick={() => {
                    dispatch(closeModalAction())
                }}>Hủy</Button>
                <Button type="primary" className="ml-2" onClick={() => {
                    let listId = listMonTongKetPK.filter(i => i.check === true).map(i => {
                        return i.id
                    })
                    dispatch(phucKhaoDiemTongKetAction(userInfo?.username, namHoc, kyHoc, listId))
                }}> Nộp đơn</Button>
            </div>
        </div>

    )
}
