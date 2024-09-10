import { Button, Checkbox } from "antd";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { diemThiState, getListMonThiPKAction, phucKhaoDiemThiAction, setListMonThiPK } from "../../../reducers/diemThiReducer/diemThiReducer";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import { closeModalAction } from "../../../reducers/modalReducer/modalReducer";

export default function PhucKhaoDiemThi(props) {

    const dispatch = useDispatch();

    const { listMonThiPK, namHoc, kyThi } = useSelector(diemThiState)
    const { userInfo } = useSelector(globalState)

    useEffect(() => {
        dispatch(getListMonThiPKAction(userInfo?.lopIdHienTai))
    }, [])

    return (
        <div>
            <span>Chú ý : Vui lòng chọn các môn tổng kết bạn muốn phúc khảo điểm</span>
            <div className="grid-cols-2 grid mt-3">
                {
                    listMonThiPK?.map((item, index) => {
                        return (
                            <div key={index} className="col-span-1 mt-2" >
                                <Checkbox checked={item?.check} onChange={(e) => {
                                    let newList = listMonThiPK.map((item) => {
                                        return {
                                            ...item
                                        }
                                    })
                                    newList[index].check = e.target.checked;
                                    dispatch(setListMonThiPK([...newList]));
                                }}>
                                    {item?.tenMonThi}
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
                    let listId = listMonThiPK.filter(i => i.check === true).map(i => {
                        return i.id
                    })
                    dispatch(phucKhaoDiemThiAction(userInfo?.username, namHoc, kyThi, listId))
                }} >Nộp đơn</Button>
            </div>
        </div>

    )
}
