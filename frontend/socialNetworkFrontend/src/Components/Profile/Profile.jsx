import React from 'react'
import styles from './Profile.module.scss'
import ava from '../../assets/ava1.jpg'
import ava2 from '../../assets/ava6.jpg'
import ava3 from '../../assets/ava7.jpg'
import ava4 from '../../assets/ava8.jpg'
import ava5 from '../../assets/ava9.jpg'

import { GoPlus } from "react-icons/go";

export default function Profile() {
    return (
        <div className={styles.wrapper}>
            <div className={styles.section1}>
                <div className={styles.avatar_wrapper}>
                    <img className={styles.avatar} src={ava} alt=""/>
                </div>
                <div className={styles.userName}>TylerDyrden</div>
                <div className={styles.button}>Редактировать профиль</div>
                <div className={styles.statistics_wrapper}>
                    <div className={styles.publications_counter}>9 <span>публикаций</span></div>
                    <div className={styles.followers_counter}>132 <span>подписчиков</span></div>
                    <div className={styles.followee_counter}>140 <span>подписок</span></div>
                </div>
                <div className={styles.bio}>
                    The first rule of Fight Club is: you do not talk about Fight Club...
                </div>
            </div>
            <div className={styles.section2}>
                <div className={styles.story_wrapper}>
                    <div className={styles.story}>
                        <div className={styles.story_image}>
                            <GoPlus size={48}/>
                        </div>
                    </div>
                    <div className={styles.story_title}>
                        Добавить
                    </div>
                </div>
            </div>
            <hr className={styles.line}/>
            <div className={styles.section3}>
                <img className={styles.images} src={ava} alt=""/>
                <img className={styles.images} src={ava2} alt=""/>
                <img className={styles.images} src={ava3} alt=""/>
                <img className={styles.images} src={ava4} alt=""/>
                <img className={styles.images} src={ava5} alt=""/>

            </div>
        </div>
    )
}
