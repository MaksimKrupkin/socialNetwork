import React from 'react'
import styles from './FollowersList.module.scss'
import { IoPersonAdd } from "react-icons/io5";
import ava1 from '../../assets/ava1.jpg'
import ava2 from '../../assets/ava2.jpg'
import ava3 from '../../assets/ava3.jpg'
import ava4 from '../../assets/ava4.jpg'
import ava5 from '../../assets/ava5.jpg'
import {TbMessageCircle} from "react-icons/tb";

export default function FollowersList() {
    return (
        <div className={styles.wrapper}>
            <div className={styles.title}>Подписчики</div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava1} alt=""/>
                <div className={styles.userName}>BradPitt</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava2} alt=""/>
                <div className={styles.userName}>Walter White</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava3} alt=""/>
                <div className={styles.userName}>ScarFace</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava4} alt=""/>
                <div className={styles.userName}>Marcus Avrelius</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava5} alt=""/>
                <div className={styles.userName}>Matthew McConaughey</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava1} alt=""/>
                <div className={styles.userName}>BradPitt</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava2} alt=""/>
                <div className={styles.userName}>Walter White</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava3} alt=""/>
                <div className={styles.userName}>ScarFace</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava4} alt=""/>
                <div className={styles.userName}>Marcus Avrelius</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
            <div className={styles.follower_wrapper}>
                <img className={styles.image} src={ava5} alt=""/>
                <div className={styles.userName}>Matthew McConaughey</div>
                <div className={styles.toMessageWrapper}>
                    <div className={styles.toMessage}>Написать сообщение</div>
                    <TbMessageCircle fontSize={14}/>
                </div>
                <div className={styles.toFollowWrapper}>
                    <div className={styles.toFollow}>Подписаться</div>
                    <IoPersonAdd/>
                </div>
            </div>
        </div>
    )
}
