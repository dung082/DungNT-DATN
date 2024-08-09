import { useDispatch } from "react-redux"

export default function PopUpComponent(props) {
    const { Action, Title, Key } = props
    const dispatch = useDispatch()
    return (
        <span className="popup-action"
            onClick={() => {
                dispatch(Action)
            }}
            key={Key}
        >
            {Title}
        </span>
    )
}
