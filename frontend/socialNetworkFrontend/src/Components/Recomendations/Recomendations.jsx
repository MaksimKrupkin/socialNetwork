import React from 'react'
import styles from './Recomendations.module.scss'
import ava1 from '../../assets/ava1.jpg'
import ava2 from '../../assets/ava2.jpg'
import ava3 from '../../assets/ava3.jpg'

export default function Recomendations() {
    return (
        <div className={styles.wrapper}>
            <div className={styles.title}>Возможно, вы знакомы</div>
            <div className={styles.item_wrapper}>
                <img className={styles.image} src={ava1} alt=""/>
                <div className={styles.info_wrapper}>
                    <div className={styles.userName}>TylerDurden</div>
                    <div className={styles.follower}>Подписаны: Peter_Parker</div>
                </div>
                <div className={styles.toSubscribe}>Подписаться</div>
            </div>
            <div className={styles.item_wrapper}>
                <img className={styles.image} src={ava2} alt=""/>
                <div className={styles.info_wrapper}>
                    <div className={styles.userName}>Walter_White</div>
                    <div className={styles.follower}>Подписаны: Tony Stark</div>
                </div>
                <div className={styles.toSubscribe}>Подписаться</div>
            </div>
            <div className={styles.item_wrapper}>
                <img className={styles.image} src={ava3} alt=""/>
                <div className={styles.info_wrapper}>
                    <div className={styles.userName}>ScarFace</div>
                    <div className={styles.follower}>Подписаны: Tony.Brasko</div>
                </div>
                <div className={styles.toSubscribe}>Подписаться</div>
            </div>
            
        </div>
    )
}
